using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities;

namespace NetModular.Module.CodeGenerator.Domain.OnlineModule
{
    /// <summary>
    /// 在线模块
    /// </summary>
    [Table("Online_Module")]
    public partial class OnlineModuleEntity : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 介绍说明
        /// </summary>
		[Nullable]
        [Length(500)]
        public string Description { get; set; }

        /// <summary>
        /// NuGet包ID
        /// </summary>
        [Length(200)]
        public string NuGetId { get; set; }

        /// <summary>
        /// NPM包ID
        /// </summary>
        [Length(200)]
        public string NpmId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Length(200)]
        public string Company { get; set; }

        /// <summary>
        /// 项目地址
        /// </summary>
        [Length(300)]
        public string ProjectUrl { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        [Length(300)]
        public string RepositoryUrl { get; set; }

    }
}
