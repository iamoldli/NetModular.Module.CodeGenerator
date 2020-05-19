using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Config.Abstractions;
using NetModular.Lib.Config.Abstractions.Impl;
using NetModular.Module.CodeGenerator.Application.ModuleService;
using NetModular.Module.CodeGenerator.Application.ModuleService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.Module.Models;
using NetModular.Module.CodeGenerator.Infrastructure;

namespace NetModular.Module.CodeGenerator.Web.Controllers
{
    [Description("模块管理")]
    public class ModuleController : Web.ModuleController
    {
        private readonly IModuleService _service;
        private readonly IConfigProvider _configProvider;
        public ModuleController( IModuleService service, IConfigProvider configProvider)
        {
            _service = service;
            _configProvider = configProvider;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]ModuleQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(ModuleAddModel model)
        {
            return _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public Task<IResultModel> Delete([BindRequired]Guid id)
        {
            return _service.Delete(id);
        }

        [HttpGet]
        [Description("编辑")]
        public Task<IResultModel> Edit([BindRequired]Guid id)
        {
            return _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(ModuleUpdateModel model)
        {
            return _service.Update(model);
        }

        [HttpPost]
        [Description("生成代码")]
        public async Task<IActionResult> BuildCode(ModuleBuildCodeModel model)
        {
            var result = await _service.BuildCode(model);
            return PhysicalFile(result.Data.ZipPath, "application/octet-stream", result.Data.Name, true);
        }
    }
}
