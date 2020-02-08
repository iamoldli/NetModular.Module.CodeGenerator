using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NetModular.Lib.Utils.Core.Extensions;
using NetModular.Module.CodeGenerator.Domain.Property;
using NetModular.Module.CodeGenerator.Infrastructure.Templates.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Templates.Default.T4.src.Library.Domain
{
    public partial class Entity : ITemplateHandler
    {
        /// <summary>
        /// 已创建的枚举列表
        /// </summary>
        private readonly List<Guid> _hasCreadedEnumList = new List<Guid>();
        private readonly TemplateBuildModel _model;
        private readonly string _prefix;
        private ClassBuildModel _class;
        private List<PropertyBuildModel> _propertyList;

        private string _baseEntityName;//基类实体名称

        public Entity(TemplateBuildModel model)
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

                    var dir = Path.Combine(_model.RootPath, "src/Library/Domain", _class.Name);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    _baseEntityName = _class.BaseEntityType.ToDescription();
                    if (_baseEntityName.Contains("Guid"))
                    {
                        _baseEntityName = _baseEntityName.Replace("<Guid>", "");
                    }

                    if (_baseEntityName.Contains("SoftDelete"))
                    {
                        _baseEntityName = _baseEntityName.Replace(">", ", Guid>");
                    }

                    _propertyList = _class.PropertyList ?? new List<PropertyBuildModel>();

                    //清空
                    GenerationEnvironment.Clear();

                    var content = TransformText();

                    var filePath = Path.Combine(dir, _class.Name + "Entity.cs");
                    File.WriteAllText(filePath, content);

                    #region ==处理枚举==

                    foreach (var property in classModel.PropertyList)
                    {
                        if (property.Type == PropertyType.Enum && property.Enum != null && !_hasCreadedEnumList.Contains(property.Enum.Id))
                        {
                            var enumHandler = new EntityEnum(_model, classModel, property.Enum);
                            var enumContent = enumHandler.TransformText();
                            var enumFilePath = Path.Combine(dir, property.Enum.Name + ".cs");
                            File.WriteAllText(enumFilePath, enumContent);
                        }
                    }

                    #endregion

                }
            }
        }

        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <returns></returns>
        public string GetDefaultValue(PropertyBuildModel property)
        {
            if (!property.HasDefaultValue)
                return string.Empty;

            if (property.Type == PropertyType.DateTime)
                return " = DateTime.Now;";
            if (property.Type == PropertyType.String)
                return " = string.Empty;";

            return string.Empty;
        }
    }
}
