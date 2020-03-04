using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.CodeGenerator.Application.ModuleService.ViewModels
{
    /// <summary>
    /// 添加模块
    /// </summary>
    public class ModuleAddModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入名称")]
        public string Name { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Range(0, 59315, ErrorMessage = "编码在 0 到 59315 之间")]
        public int No { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "请输入编码")]
        public string Code { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Required(ErrorMessage = "请选择图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 版权声明
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// 公司单位
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 官方地址
        /// </summary>
        public string ProjectUrl { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        public string RepositoryUrl { get; set; }
    }
}
