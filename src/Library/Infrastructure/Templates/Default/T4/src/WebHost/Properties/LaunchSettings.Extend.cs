using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.WebHost.Properties
{
    public partial class LaunchSettings : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;

        public LaunchSettings(TemplateBuildModel model)
        {
            _model = model;
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, "src/WebHost/Properties/");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();
            var filePath = Path.Combine(dir, "launchSettings.json");
            File.WriteAllText(filePath, content);
        }
    }
}
