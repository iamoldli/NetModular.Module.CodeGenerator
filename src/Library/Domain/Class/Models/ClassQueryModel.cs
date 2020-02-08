using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Lib.Data.Query;

namespace NetModular.Module.CodeGenerator.Domain.Class.Models
{
    public class ClassQueryModel : QueryModel
    {
        /// <summary>
        /// 所有模块
        /// </summary>
        [Required(ErrorMessage = "选择模块")]
        public Guid ModuleId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
