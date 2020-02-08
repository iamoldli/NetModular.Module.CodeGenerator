using System.Collections.Generic;
using System.IO;
using System.Linq;
using NetModular.Module.CodeGenerator.Domain.ModelProperty;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.Library.Domain.Models
{
    public partial class QueryModel : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;
        private ClassBuildModel _class;
        private List<ModelPropertyBuildModel> _propertyList;

        public QueryModel(TemplateBuildModel model)
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

                    var dir = Path.Combine(_model.RootPath, "src/Library/Domain", _class.Name, "Models");
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    _propertyList = classModel.ModelPropertyList
                        .Where(m => m.ModelType == ModelType.Query).ToList();

                    //清空
                    GenerationEnvironment.Clear();

                    var content = TransformText();

                    var filePath = Path.Combine(dir, $"{_class.Name}QueryModel.cs");
                    File.WriteAllText(filePath, content);
                }
            }
        }
    }
}
