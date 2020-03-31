using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Module.CodeGenerator.Application.EnumService;
using NetModular.Module.CodeGenerator.Application.EnumService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.Enum.Models;

namespace NetModular.Module.CodeGenerator.Web.Controllers
{
    [Description("枚举管理")]
    public class EnumController : Web.ModuleController
    {
        private readonly IEnumService _service;

        public EnumController(IEnumService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery] EnumQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(EnumAddModel model)
        {
            return _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public Task<IResultModel> Delete([BindRequired] Guid id)
        {
            return _service.Delete(id);
        }

        [HttpGet]
        [Description("编辑")]
        public Task<IResultModel> Edit([BindRequired] Guid id)
        {
            return _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(EnumUpdateModel model)
        {
            return _service.Update(model);
        }


        [HttpGet]
        [Description("下拉列表")]
        [Common]
        public Task<IResultModel> Select()
        {
            return _service.Select();
        }
    }
}
