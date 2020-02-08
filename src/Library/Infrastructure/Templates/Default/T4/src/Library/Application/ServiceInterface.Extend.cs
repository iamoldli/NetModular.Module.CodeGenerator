using System.IO;
using System.Linq;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.Library.Application
{
    public partial class ServiceInterface : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;
        private ClassBuildModel _class;

        public ServiceInterface(TemplateBuildModel model)
        {
            _model = model;
            _prefix = model.Module.Prefix;
        }

        public bool IsGlobal => false;

        public void Save()
        {
            if (_model.Module.ClassList != null && _model.Module.ClassList.Any())
            {
                foreach (var classModel in _model.Module.ClassList)
                {
                    _class = classModel;

                    var dir = Path.Combine(_model.RootPath, "src/Library/Application", _class.Name + "Service");
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    //清空
                    GenerationEnvironment.Clear();

                    var content = TransformText();

                    var filePath = Path.Combine(dir, $"I{_class.Name}Service.cs");
                    File.WriteAllText(filePath, content);
                }
            }
        }
    }
}
