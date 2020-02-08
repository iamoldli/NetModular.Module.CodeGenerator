using System.Collections.Generic;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Models
{
    /// <summary>
    /// 模块生成模型
    /// </summary>
    public class ModuleBuildModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// 前端组件前缀
        /// </summary>
        public string UiPrefix { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 版权声明
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// 类列表
        /// </summary>
        public List<ClassBuildModel> ClassList { get; set; } = new List<ClassBuildModel>();

        /// <summary>
        /// 前端代码目录名称
        /// </summary>
        public string WebUIDicName => $"module-{Code.ToLower()}";
    }
}
