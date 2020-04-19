using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.Library.Infrastructure
{
    public partial class Config : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;

        public Config(TemplateBuildModel model)
        {
            _model = model;
            _prefix = model.Module.Prefix;
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, "src/Library/Infrastructure");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();
            var filePath = Path.Combine(dir, $"{_model.Module.Code}Config.cs");
            File.WriteAllText(filePath, content);
        }
    }
}
