using System.IO;
using System.Linq;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.Library.Infrastructure.Repositories
{
    public partial class MySqlRepository : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;
        private ClassBuildModel _class;

        public MySqlRepository(TemplateBuildModel model)
        {
            _model = model;
            _prefix = model.Module.Prefix;
        }

        public bool IsGlobal => false;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, "src/Library/Infrastructure/Repositories/MySql");
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

                    var filePath = Path.Combine(dir, $"{_class.Name}Repository.cs");
                    File.WriteAllText(filePath, content);
                }
            }
        }
    }
}
