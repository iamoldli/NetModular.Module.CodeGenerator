using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.CodeGenerator.Domain.Class.Models;

namespace NetModular.Module.CodeGenerator.Domain.Class
{
    /// <summary>
    /// 实体信息仓储
    /// </summary>
    public interface IClassRepository : IRepository<ClassEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<ClassEntity>> Query(ClassQueryModel model);

        /// <summary>
        /// 查询指定模块的所有类列表
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        Task<IList<ClassEntity>> QueryAllByModule(Guid moduleId);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <returns></returns>
        Task<bool> Exists(ClassEntity entity);

        /// <summary>
        /// 删除制定模块的所有类
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<bool> DeleteByModule(Guid moduleId, IUnitOfWork uow);
    }
}
