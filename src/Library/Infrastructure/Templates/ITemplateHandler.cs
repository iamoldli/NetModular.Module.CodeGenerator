namespace NetModular.Module.CodeGenerator.Infrastructure.Templates
{
    /// <summary>
    /// 模板处理
    /// </summary>
    public interface ITemplateHandler
    {
        /// <summary>
        /// 是否是全局文件
        /// </summary>
        bool IsGlobal { get; }

        /// <summary>
        /// 保存
        /// </summary>
        void Save();
    }
}
