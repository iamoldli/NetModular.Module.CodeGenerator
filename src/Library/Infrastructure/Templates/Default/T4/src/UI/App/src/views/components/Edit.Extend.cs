using System.IO;
using System.Linq;
using NetModular.Lib.Utils.Core.Extensions;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.UI.App.src.views.components
{
    public partial class Edit : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private ClassBuildModel _class;
        private readonly string _prefix;
        private readonly string _uiPrefix;

        public Edit(TemplateBuildModel model)
        {
            _model = model;
            _prefix = _model.Project.Prefix.ToLower();
            _uiPrefix = _model.Project.UIPrefix.ToLower();
        }

        public void Save()
        {
            if (_model.Project.ClassList != null && _model.Project.ClassList.Any())
            {
                foreach (var classModel in _model.Project.ClassList)
                {
                    _class = classModel;

                    var dir = Path.Combine(_model.RootPath, _model.Project.Code, $"src/UI/{_model.Project.WebUIDicName}/src/views", _class.Name.FirstCharToLower(), "components/edit");
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    //清空
                    GenerationEnvironment.Clear();

                    var content = TransformText();

                    var filePath = Path.Combine(dir, $"index.vue");
                    File.WriteAllText(filePath, content);
                }
            }
        }
    }
}
