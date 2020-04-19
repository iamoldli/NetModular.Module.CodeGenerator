using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Config.Abstractions;
using NetModular.Lib.Config.Abstractions.Impl;
using NetModular.Module.CodeGenerator.Application.ModuleService.ResultModels;
using NetModular.Module.CodeGenerator.Application.ModuleService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.Class;
using NetModular.Module.CodeGenerator.Domain.ClassMethod;
using NetModular.Module.CodeGenerator.Domain.Enum;
using NetModular.Module.CodeGenerator.Domain.EnumItem;
using NetModular.Module.CodeGenerator.Domain.ModelProperty;
using NetModular.Module.CodeGenerator.Domain.Module;
using NetModular.Module.CodeGenerator.Domain.Module.Models;
using NetModular.Module.CodeGenerator.Domain.Property;
using NetModular.Module.CodeGenerator.Infrastructure;
using NetModular.Module.CodeGenerator.Infrastructure.NuGet;
using NetModular.Module.CodeGenerator.Infrastructure.Repositories;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Default;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Application.ModuleService
{
    public class ModuleService : IModuleService
    {
        private readonly IMapper _mapper;
        private readonly IModuleRepository _repository;
        private readonly IClassRepository _classRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IEnumRepository _enumRepository;
        private readonly IEnumItemRepository _enumItemRepository;
        private readonly IModelPropertyRepository _modelPropertyRepository;
        private readonly IClassMethodRepository _classMethodRepository;
        private readonly CodeGeneratorDbContext _dbContext;
        private readonly NuGetHelper _nugetHelper;
        private readonly IConfigProvider _configProvider;

        public ModuleService(IModuleRepository repository, IMapper mapper, IClassRepository classRepository, IPropertyRepository propertyRepository, IEnumRepository enumRepository, IEnumItemRepository enumItemRepository, IModelPropertyRepository modelPropertyRepository, IClassMethodRepository classMethodRepository, CodeGeneratorDbContext dbContext, NuGetHelper nugetHelper, IConfigProvider configProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _classRepository = classRepository;
            _propertyRepository = propertyRepository;
            _enumRepository = enumRepository;
            _enumItemRepository = enumItemRepository;
            _modelPropertyRepository = modelPropertyRepository;
            _classMethodRepository = classMethodRepository;
            _dbContext = dbContext;
            _nugetHelper = nugetHelper;
            _configProvider = configProvider;
        }

        public async Task<IResultModel> Query(ModuleQueryModel model)
        {
            var result = new QueryResultModel<ModuleEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(ModuleAddModel model)
        {
            var entity = _mapper.Map<ModuleEntity>(model);
            var result = await _repository.AddAsync(entity);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Delete(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            using (var uow = _dbContext.NewUnitOfWork())
            {
                var result = await _repository.SoftDeleteAsync(id, uow);
                if (result)
                {
                    result = await _classRepository.DeleteByModule(id, uow);
                    if (result)
                    {
                        result = await _propertyRepository.DeleteByModule(id, uow);
                        if (result)
                        {
                            result = await _modelPropertyRepository.DeleteByModule(id, uow);
                            if (result)
                            {
                                uow.Commit();
                                return ResultModel.Success();
                            }
                        }
                    }
                }
            }

            return ResultModel.Failed();
        }

        public async Task<IResultModel> Edit(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<ModuleUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(ModuleUpdateModel model)
        {
            var entity = await _repository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            _mapper.Map(model, entity);

            var result = await _repository.UpdateAsync(entity);
            return ResultModel.Result(result);
        }

        public Task<IResultModel<ModuleBuildCodeResultModel>> BuildCode(ModuleBuildCodeModel model)
        {
            return BuildCode(model.Id);
        }

        public async Task<IResultModel<ModuleBuildCodeResultModel>> BuildCode(Guid moduleId, IList<ClassEntity> classList = null)
        {
            var result = new ResultModel<ModuleBuildCodeResultModel>();

            var module = await _repository.GetAsync(moduleId);
            if (module == null)
                return result.Failed("模块不存在");

            //创建模块生成对象
            var moduleBuildModel = _mapper.Map<ModuleBuildModel>(module);

            var config = _configProvider.Get<CodeGeneratorConfig>();
            moduleBuildModel.Prefix = config.Prefix;
            moduleBuildModel.UiPrefix = config.UiPrefix;

            var id = Guid.NewGuid().ToString();
            var rootPath = config.BuildCodePath;
            if (rootPath.IsNull())
            {
                var pathConfig = _configProvider.Get<PathConfig>();
                rootPath = Path.Combine(pathConfig.TempPath, "CodeGenerator/BuildCode");
            }

            var moduleFullName = $"{config.Prefix}.Module.{module.Code}";
            var buildModel = new TemplateBuildModel
            {
                RootPath = Path.Combine(rootPath, id, moduleFullName),
                NuGetPackageVersions = _nugetHelper.GetVersions()
            };

            if (classList == null)
            {
                //如果classList参数为null，表示生成整个解决方案
                buildModel.GenerateSln = true;
                classList = await _classRepository.QueryAllByModule(module.Id);
            }

            foreach (var classEntity in classList)
            {
                var classBuildModel = _mapper.Map<ClassBuildModel>(classEntity);
                var propertyList = await _propertyRepository.QueryByClass(classEntity.Id);
                if (propertyList.Any())
                {
                    //查询属性
                    foreach (var propertyEntity in propertyList)
                    {
                        var propertyBuildModel = _mapper.Map<PropertyBuildModel>(propertyEntity);

                        //如果属性类型是枚举，查询枚举信息
                        if (propertyEntity.Type == PropertyType.Enum && propertyEntity.EnumId.NotEmpty())
                        {
                            var enumEntity = await _enumRepository.GetAsync(propertyEntity.EnumId);
                            propertyBuildModel.Enum = new EnumBuildModel
                            {
                                Name = enumEntity.Name,
                                Remarks = enumEntity.Remarks
                            };

                            var enumItemList = await _enumItemRepository.QueryByEnum(propertyEntity.EnumId);
                            propertyBuildModel.Enum.ItemList = enumItemList.Select(m => new EnumItemBuildModel
                            {
                                Name = m.Name,
                                Remarks = m.Remarks,
                                Value = m.Value
                            }).ToList();
                        }

                        classBuildModel.PropertyList.Add(propertyBuildModel);
                    }
                }

                var modelPropertyList = await _modelPropertyRepository.QueryByClass(classEntity.Id);

                if (modelPropertyList.Any())
                {
                    foreach (var propertyEntity in modelPropertyList)
                    {
                        var modelPropertyBuildModel = _mapper.Map<ModelPropertyBuildModel>(propertyEntity);
                        //如果属性类型是枚举，查询枚举信息
                        if (propertyEntity.Type == PropertyType.Enum && propertyEntity.EnumId.NotEmpty())
                        {
                            var enumEntity = await _enumRepository.GetAsync(propertyEntity.EnumId);
                            modelPropertyBuildModel.Enum = new EnumBuildModel
                            {
                                Name = enumEntity.Name,
                                Remarks = enumEntity.Remarks
                            };

                            var enumItemList = await _enumItemRepository.QueryByEnum(propertyEntity.EnumId);
                            modelPropertyBuildModel.Enum.ItemList = enumItemList.Select(m => new EnumItemBuildModel
                            {
                                Name = m.Name,
                                Remarks = m.Remarks,
                                Value = m.Value
                            }).ToList();
                        }

                        classBuildModel.ModelPropertyList.Add(modelPropertyBuildModel);
                    }
                }

                classBuildModel.Method = await _classMethodRepository.GetByClass(classEntity.Id);

                moduleBuildModel.ClassList.Add(classBuildModel);
            }

            buildModel.Module = moduleBuildModel;

            var builder = new DefaultTemplateBuilder();
            builder.Build(buildModel);

            var sourceDir = Path.Combine(rootPath, id);
            var outputFile = Path.Combine(rootPath, id + ".zip");
            ZipFile.CreateFromDirectory(sourceDir, outputFile);

            //删除临时文件
            Directory.Delete(sourceDir, true);

            var resultModel = new ModuleBuildCodeResultModel
            {
                Id = id,
                Name = moduleBuildModel.Name + ".zip",
                ZipPath = outputFile
            };

            return result.Success(resultModel);
        }
    }
}
