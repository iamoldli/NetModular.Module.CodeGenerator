using NetModular.Lib.Config.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure
{
    public class CodeGeneratorConfig : IConfig
    {
        /// <summary>
        /// 生成代码存储路径
        /// </summary>
        public string BuildCodePath { get; set; }

        /// <summary>
        /// 模块前缀(后端命名空间)
        /// </summary>
        public string Prefix { get; set; } = "NetModular";

        /// <summary>
        /// 前端组件前缀
        /// </summary>
        public string UiPrefix { get; set; } = "Nm";
    }
}
