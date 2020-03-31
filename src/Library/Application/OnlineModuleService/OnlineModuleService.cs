using System;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Module.CodeGenerator.Application.OnlineModuleService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.OnlineModule;
using NetModular.Module.CodeGenerator.Domain.OnlineModule.Models;

namespace NetModular.Module.CodeGenerator.Application.OnlineModuleService
{
    public class OnlineModuleService : IOnlineModuleService
    {
        private readonly IMapper _mapper;
        private readonly IOnlineModuleRepository _repository;
        public OnlineModuleService(IMapper mapper, IOnlineModuleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResultModel> Query(OnlineModuleQueryModel model)
        {
            var result = new QueryResultModel<OnlineModuleEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(OnlineModuleAddModel model)
        {
            var entity = _mapper.Map<OnlineModuleEntity>(model);
            //if (await _repository.Exists(entity))
            //{
                //return ResultModel.HasExists;
            //}

            var result = await _repository.AddAsync(entity);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Edit(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<OnlineModuleUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(OnlineModuleUpdateModel model)
        {
            var entity = await _repository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            _mapper.Map(model, entity);

            //if (await _repository.Exists(entity))
            //{
                //return ResultModel.HasExists;
            //}

            var result = await _repository.UpdateAsync(entity);

            return ResultModel.Result(result);
        }
    }
}
