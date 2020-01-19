using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4
{
    public partial class Readme : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;

        public Readme(TemplateBuildModel model)
        {
            _model = model;
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var content = TransformText();
            var filePath = Path.Combine(_model.RootPath, "README.md");
            File.WriteAllText(filePath, content);
        }
    }
}
