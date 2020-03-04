using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.CodeGenerator.Domain.Module
{
    /// <summary>
    /// 模块信息
    /// </summary>
    [Table("Module")]
    public partial class ModuleEntity : EntityBaseWithSoftDelete
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Length(100)]
        public string Name { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Nullable]
        public string Icon { get; set; }

        /// <summary>
        /// 版权声明
        /// </summary>
        [Nullable]
        [Length(200)]
        public string Copyright { get; set; }

        /// <summary>
        /// 公司单位
        /// </summary>
        [Nullable]
        [Length(100)]
        public string Company { get; set; }

        /// <summary>
        /// 官方地址
        /// </summary>
        [Nullable]
        [Length(300)]
        public string ProjectUrl { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        [Nullable]
        [Length(300)]
        public string RepositoryUrl { get; set; }
    }
}
