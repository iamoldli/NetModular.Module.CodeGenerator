using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.WebHost
{
    public partial class AppSettingsDevelopment : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;

        public AppSettingsDevelopment(TemplateBuildModel model)
        {
            _model = model;
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, "src/WebHost");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();
            var filePath = Path.Combine(dir, "appsettings.Development.json");
            File.WriteAllText(filePath, content);
        }
    }
}
