using System;
using System.Threading.Tasks;
using NetModular.Module.CodeGenerator.Application.OnlineModuleService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.OnlineModule.Models;

namespace NetModular.Module.CodeGenerator.Application.OnlineModuleService
{
    /// <summary>
    /// 在线模块服务
    /// </summary>
    public interface IOnlineModuleService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Query(OnlineModuleQueryModel model);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Add(OnlineModuleAddModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<IResultModel> Delete(Guid id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> Edit(Guid id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Update(OnlineModuleUpdateModel model);

    }
}
