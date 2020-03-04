using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.CodeGenerator.Application.OnlineModuleService.ViewModels;
using NetModular.Module.CodeGenerator.Domain.OnlineModule;

namespace NetModular.Module.CodeGenerator.Application.OnlineModuleService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<OnlineModuleAddModel, OnlineModuleEntity>();
            cfg.CreateMap<OnlineModuleEntity, OnlineModuleUpdateModel>();
            cfg.CreateMap<OnlineModuleUpdateModel, OnlineModuleEntity>();
        }
    }
}
