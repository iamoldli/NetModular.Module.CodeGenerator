using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.CodeGenerator.Domain.OnlineModule;

namespace NetModular.Module.CodeGenerator.Application.OnlineModuleService.ViewModels
{
    /// <summary>
    /// 在线模块添加模型
    /// </summary>
    public class OnlineModuleUpdateModel : OnlineModuleAddModel
    {
        [Required(ErrorMessage = "请选择要修改的在线模块")]
        public Guid Id { get; set; }
    }
}
