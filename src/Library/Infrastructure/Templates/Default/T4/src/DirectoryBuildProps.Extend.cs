using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src
{
    public partial class DirectoryBuildProps : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;
        private readonly string _company;
        private readonly string _copyright;
        private readonly string _projectUrl;
        private readonly string _repositoryUrl;

        public DirectoryBuildProps(TemplateBuildModel model)
        {
            _model = model;
            _prefix = model.Module.Prefix;
            _company = model.Module.Company ?? "";
            _copyright = model.Module.Copyright ?? "";
            _projectUrl = model.Module.ProjectUrl ?? "";
            _repositoryUrl = model.Module.RepositoryUrl ?? "";
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, "src");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();
            var filePath = Path.Combine(dir, "Directory.Build.props");
            File.WriteAllText(filePath, content);
        }
    }
}
