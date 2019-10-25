using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.CodeGenerator.Domain.Project
{
    /// <summary>
    /// 项目
    /// </summary>
    [Table("Project")]
    public partial class ProjectEntity : EntityBaseWithSoftDelete
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
    }
}
