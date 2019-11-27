using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.script
{
    public partial class NpmUpdate : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;

        public NpmUpdate(TemplateBuildModel model)
        {
            _model = model;
        }

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, "script");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();

            var filePath = Path.Combine(dir, "npm_update.ps1");
            File.WriteAllText(filePath, content);
        }
    }
}
