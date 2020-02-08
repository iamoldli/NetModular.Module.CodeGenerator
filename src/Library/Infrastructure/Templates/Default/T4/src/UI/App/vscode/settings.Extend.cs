using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.UI.App.vscode
{
    public partial class settings : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;

        public settings(TemplateBuildModel model)
        {
            _model = model;
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var content = TransformText();
            var dir = Path.Combine(_model.RootPath, $"src/UI/{_model.Module.WebUIDicName}/.vscode");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var filePath = Path.Combine(dir, "settings.json");
            File.WriteAllText(filePath, content);
        }
    }
}
