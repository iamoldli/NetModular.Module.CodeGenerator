using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.UI.App.src.components
{
    public partial class ConfigPage : ITemplateHandler
    {
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;
        private readonly string _uiPrefix;

        public ConfigPage(TemplateBuildModel model)
        {
            _model = model;
            _prefix = _model.Module.Prefix.ToLower();
            _uiPrefix = _model.Module.UiPrefix.ToLower();
        }

        public bool IsGlobal => true;

        public void Save()
        {
            var dir = Path.Combine(_model.RootPath, $"src/UI/{_model.Module.WebUIDicName}/src/components/config-{_model.Module.Code.ToLower()}");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var content = TransformText();
            var filePath = Path.Combine(dir, "index.vue");
            File.WriteAllText(filePath, content);
        }
    }
}
