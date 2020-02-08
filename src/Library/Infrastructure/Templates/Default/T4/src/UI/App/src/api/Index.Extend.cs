using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.UI.App.src.api
{
    public partial class Index : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;

        public Index(TemplateBuildModel model)
        {
            _model = model;
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, $"src/UI/{_model.Module.WebUIDicName}/src/api");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();
            var filePath = Path.Combine(dir, "index.js");
            File.WriteAllText(filePath, content);
        }
    }
}
