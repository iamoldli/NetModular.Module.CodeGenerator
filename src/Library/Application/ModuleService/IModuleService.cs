using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Module.CodeGenerator.Application.ModuleService.ResultModels;
using NetModular.Module.CodeGenerator.Application.ModuleService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.Class;
using NetModular.Module.CodeGenerator.Domain.Module.Models;

namespace NetModular.Module.CodeGenerator.Application.ModuleService
{
    /// <summary>
    /// 项目服务
    /// </summary>
    public interface IModuleService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Query(ModuleQueryModel model);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Add(ModuleAddModel model);

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
        Task<IResultModel> Update(ModuleUpdateModel model);

        /// <summary>
        /// 生成代码,返回文件的Guid
        /// </summary>
        /// <returns></returns>
        Task<IResultModel<ModuleBuildCodeResultModel>> BuildCode(ModuleBuildCodeModel model);

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="classList"></param>
        /// <returns></returns>
        Task<IResultModel<ModuleBuildCodeResultModel>> BuildCode(Guid projectId, IList<ClassEntity> classList = null);
    }
}
