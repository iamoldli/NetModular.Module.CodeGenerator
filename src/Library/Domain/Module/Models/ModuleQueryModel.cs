using NetModular.Lib.Data.Query;

namespace NetModular.Module.CodeGenerator.Domain.Module.Models
{
    public class ModuleQueryModel : QueryModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}
