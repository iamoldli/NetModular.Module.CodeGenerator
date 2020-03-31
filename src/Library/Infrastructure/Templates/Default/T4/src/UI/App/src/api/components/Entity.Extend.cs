using System.IO;
using System.Linq;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.UI.App.src.api.components
{
    public partial class Entity : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private ClassBuildModel _class;

        public Entity(TemplateBuildModel model)
        {
            _model = model;
        }

        public bool IsGlobal => false;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath,
                $"src/UI/{_model.Module.WebUIDicName}/src/api/components");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (_model.Module.ClassList != null && _model.Module.ClassList.Any())
            {
                foreach (var classModel in _model.Module.ClassList)
                {
                    _class = classModel;

                    //清空
                    GenerationEnvironment.Clear();

                    var content = TransformText();

                    var filePath = Path.Combine(dir, $"{_class.Name.FirstCharToLower()}.js");
                    File.WriteAllText(filePath, content);
                }
            }
        }
    }
}
