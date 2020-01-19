namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Models
{
    /// <summary>
    /// 模板生成模型
    /// </summary>
    public class TemplateBuildModel
    {
        /// <summary>
        /// 生成整个解决方案
        /// </summary>
        public bool GenerateSln { get; set; }

        /// <summary>
        /// 代码存储根路径
        /// </summary>
        public string RootPath { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public ProjectBuildModel Project { get; set; }
    }
}
