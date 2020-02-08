using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Lib.Utils.Core.Extensions;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Lib.Utils.Core.SystemConfig;
using NetModular.Module.CodeGenerator.Application.ClassService;
using NetModular.Module.CodeGenerator.Application.ClassService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.Class;
using NetModular.Module.CodeGenerator.Domain.Class.Models;
using NetModular.Module.CodeGenerator.Infrastructure;

namespace NetModular.Module.CodeGenerator.Web.Controllers
{
    [Description("实体管理")]
    [Common]
    public class ClassController : Web.ModuleController
    {
        private readonly SystemConfigModel _systemConfig;
        private readonly CodeGeneratorOptions _codeGeneratorOptions;
        private readonly IClassService _service;

        public ClassController(SystemConfigModel systemConfig, CodeGeneratorOptions codeGeneratorOptions, IClassService service)
        {
            _systemConfig = systemConfig;
            _codeGeneratorOptions = codeGeneratorOptions;
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]ClassQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(ClassAddModel model)
        {
            return _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public async Task<IResultModel> Delete([BindRequired]Guid id)
        {
            return await _service.Delete(id);
        }

        [HttpGet]
        [Description("编辑")]
        public async Task<IResultModel> Edit([BindRequired]Guid id)
        {
            return await _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(ClassUpdateModel model)
        {
            return _service.Update(model);
        }

        [HttpGet]
        [Description("获取基类类型下拉列表")]
        [Common]
        public IResultModel BaseEntityTypeSelect()
        {
            return ResultModel.Success(EnumExtensions.ToResult<BaseEntityType>(true));
        }

        [HttpGet]
        [Description("生成代码")]
        public async Task<IActionResult> BuildCode([BindRequired]Guid id)
        {
            var result = await _service.BuildCode(id);
            var path = Path.Combine(_codeGeneratorOptions.BuildCodePath, result.Data.Id + ".zip");
            return PhysicalFile(path, "application/octet-stream", HttpUtility.UrlEncode(result.Data.Name), true);
        }
    }
}
