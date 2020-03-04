using System.IO;
using NetModular.Module.CodeGenerator.Infrastructure.NuGet;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.Library.Application
{
    public partial class Csproj : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;
        private readonly NuGetPackageVersions _versions;

        public Csproj(TemplateBuildModel model)
        {
            _model = model;
            _prefix = model.Module.Prefix;
            _versions = _model.NuGetPackageVersions;
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, "src/Library/Application");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();
            var filePath = Path.Combine(dir, "Application.csproj");
            File.WriteAllText(filePath, content);
        }
    }
}
