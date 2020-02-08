using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.CodeGenerator.Application.ModuleService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.Class;
using NetModular.Module.CodeGenerator.Domain.ModelProperty;
using NetModular.Module.CodeGenerator.Domain.Module;
using NetModular.Module.CodeGenerator.Domain.Property;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Application.ModuleService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ModuleAddModel, ModuleEntity>();
            cfg.CreateMap<ModuleEntity, ModuleUpdateModel>();
            cfg.CreateMap<ModuleUpdateModel, ModuleEntity>();

            //代码生成
            cfg.CreateMap<ModuleEntity, ModuleBuildModel>();
            cfg.CreateMap<ClassEntity, ClassBuildModel>();
            cfg.CreateMap<PropertyEntity, PropertyBuildModel>();
            cfg.CreateMap<ModelPropertyEntity, ModelPropertyBuildModel>();
        }
    }
}
