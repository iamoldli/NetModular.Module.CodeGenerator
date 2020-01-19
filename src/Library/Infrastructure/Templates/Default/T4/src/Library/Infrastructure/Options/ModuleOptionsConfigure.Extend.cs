using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.Library.Infrastructure.Options
{
    public partial class ModuleOptionsConfigure : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;

        public ModuleOptionsConfigure(TemplateBuildModel model)
        {
            _model = model;
            _prefix = model.Project.Prefix;
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, "src/Library/Infrastructure/Options");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();
            var filePath = Path.Combine(dir, "ModuleOptionsConfigure.cs");
            File.WriteAllText(filePath, content);
        }
    }
}
