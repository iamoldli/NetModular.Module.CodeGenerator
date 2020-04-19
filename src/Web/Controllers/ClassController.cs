using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Lib.Config.Abstractions;
using NetModular.Lib.Config.Abstractions.Impl;
using NetModular.Lib.Utils.Core.Extensions;
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
        private readonly IClassService _service;
        private readonly IConfigProvider _configProvider;
        public ClassController(IClassService service, IConfigProvider configProvider)
        {
            _service = service;
            _configProvider = configProvider;
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
            return PhysicalFile(result.Data.ZipPath, "application/octet-stream", HttpUtility.UrlEncode(result.Data.Name), true);
        }
    }
}
