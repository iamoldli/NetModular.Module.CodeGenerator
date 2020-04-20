using NetModular.Lib.Data.Abstractions.Attributes;

namespace NetModular.Module.CodeGenerator.Domain.Class
{
    public partial class ClassEntity
    {
        /// <summary>
        /// 基类名称
        /// </summary>
        [Ignore]
        public string BaseEntityName => BaseEntityType.ToDescription();
    }
}
