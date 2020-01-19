using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.CodeGenerator.Application.ProjectService.ViewModels
{
    /// <summary>
    /// 项目添加
    /// </summary>
    public class ProjectAddModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入项目名称")]
        public string Name { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Range(0, 59315, ErrorMessage = "编码在 0 到 59315 之间")]
        public int No { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "请输入项目编码")]
        public string Code { get; set; }

        /// <summary>
        /// 版权声明
        /// </summary>
        public string Copyright { get; set; }
    }
}
