using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.script
{
    public partial class NpmInstall : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;

        public NpmInstall(TemplateBuildModel model)
        {
            _model = model;
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, "script");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();

            var filePath = Path.Combine(dir, "npm_install.ps1");
            File.WriteAllText(filePath, content);
        }
    }
}
