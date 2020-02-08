using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.UI.App
{
    public partial class Package : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;

        public Package(TemplateBuildModel model)
        {
            _model = model;
            _prefix = _model.Module.Prefix.ToLower();
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, $"src/UI/{_model.Module.WebUIDicName}");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();
            var filePath = Path.Combine(dir, "package.json");
            File.WriteAllText(filePath, content);
        }
    }
}
