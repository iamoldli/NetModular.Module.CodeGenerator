using NetModular.Module.CodeGenerator.Infrastructure.NuGet;

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
        /// 模块模型
        /// </summary>
        public ModuleBuildModel Module { get; set; }

        /// <summary>
        /// NuGet包版本
        /// </summary>
        public NuGetPackageVersions NuGetPackageVersions { get; set; }
    }
}
