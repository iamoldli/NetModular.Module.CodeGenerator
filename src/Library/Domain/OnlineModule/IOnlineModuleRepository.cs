using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.CodeGenerator.Domain.OnlineModule.Models;

namespace NetModular.Module.CodeGenerator.Domain.OnlineModule
{
    /// <summary>
    /// 在线模块仓储
    /// </summary>
    public interface IOnlineModuleRepository : IRepository<OnlineModuleEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<OnlineModuleEntity>> Query(OnlineModuleQueryModel model);
    }
}
