namespace NetModular.Module.CodeGenerator.Application.ModuleService.ResultModels
{
    /// <summary>
    /// 项目生成代码返回模型
    /// </summary>
    public class ModuleBuildCodeResultModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 压缩文件路径
        /// </summary>
        public string ZipPath { get; set; }
    }
}
