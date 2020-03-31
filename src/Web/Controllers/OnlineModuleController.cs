using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Module.CodeGenerator.Application.OnlineModuleService;
using NetModular.Module.CodeGenerator.Application.OnlineModuleService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.OnlineModule.Models;

namespace NetModular.Module.CodeGenerator.Web.Controllers
{
    [Description("在线模块管理")]
    public class OnlineModuleController : Web.ModuleController
    {
        private readonly IOnlineModuleService _service;

        public OnlineModuleController(IOnlineModuleService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]OnlineModuleQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(OnlineModuleAddModel model)
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
        public Task<IResultModel> Update(OnlineModuleUpdateModel model)
        {
            return _service.Update(model);
        }
    }
}
