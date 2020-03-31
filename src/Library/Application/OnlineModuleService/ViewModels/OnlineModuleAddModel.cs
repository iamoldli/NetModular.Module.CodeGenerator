namespace NetModular.Module.CodeGenerator.Application.OnlineModuleService.ViewModels
{
    /// <summary>
    /// 在线模块添加模型
    /// </summary>
    public class OnlineModuleAddModel
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
        public string Description { get; set; }

        /// <summary>
        /// NuGet包ID
        /// </summary>
        public string NuGetId { get; set; }

        /// <summary>
        /// NPM包ID
        /// </summary>
        public string NpmId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 项目地址
        /// </summary>
        public string ProjectUrl { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        public string RepositoryUrl { get; set; }

    }
}
