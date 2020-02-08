using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.CodeGenerator.Domain.Module.Models;

namespace NetModular.Module.CodeGenerator.Domain.Module
{
    /// <summary>
    /// 项目仓储
    /// </summary>
    public interface IModuleRepository : IRepository<ModuleEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<ModuleEntity>> Query(ModuleQueryModel model);
    }
}
