using System.IO;
using NetModular.Lib.Options.Abstraction;
using NetModular.Lib.Utils.Core.Extensions;
using NetModular.Lib.Utils.Core.SystemConfig;

namespace NetModular.Module.CodeGenerator.Infrastructure
{
    public class CodeGeneratorOptions : IModuleOptions
    {
        private readonly SystemConfigModel _systemConfig;

        private string _buildCodePath;

        public CodeGeneratorOptions(SystemConfigModel systemConfig)
        {
            _systemConfig = systemConfig;
        }

        /// <summary>
        /// 生成代码存储路径
        /// </summary>
        [ModuleOptionDefinition("生成代码存储路径", "默认保存在全局临时目录的CodeGenerator\\BuildCode路径下")]
        public string BuildCodePath
        {
            get
            {
                if (_buildCodePath.IsNull())
                {
                    _buildCodePath = Path.Combine(_systemConfig.Path.TempPath, "CodeGenerator", "BuildCode");
                }
                else if (!Path.IsPathRooted(_buildCodePath))
                {
                    _buildCodePath = Path.Combine(_systemConfig.Path.TempPath, _buildCodePath);
                }
                return _buildCodePath;
            }
            set => _buildCodePath = value;
        }

        /// <summary>
        /// 模块前缀(后端命名空间)
        /// </summary>
        [ModuleOptionDefinition("模块前缀", "该属性会作为后端命名空间前缀使用，如NetModular.Module.Admin")]
        public string Prefix { get; set; } = "NetModular";

        /// <summary>
        /// 前端组件前缀
        /// </summary>
        [ModuleOptionDefinition("前端组件前缀", "前端组件前缀，如Nm，组件名称就是nm-list")]
        public string UiPrefix { get; set; } = "Nm";

        public IModuleOptions Copy()
        {
            return new CodeGeneratorOptions(_systemConfig)
            {
                BuildCodePath = BuildCodePath,
                Prefix = Prefix,
                UiPrefix = UiPrefix
            };
        }
    }
}
