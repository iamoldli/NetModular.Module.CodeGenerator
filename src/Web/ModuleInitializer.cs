using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetModular.Lib.Module.Abstractions;
using NetModular.Lib.Module.AspNetCore;

namespace NetModular.Module.CodeGenerator.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        /// <summary>
        /// 注入服务
        /// </summary>
        public void ConfigureServices(IServiceCollection services, IModuleCollection modules, IHostEnvironment env, IConfiguration cfg)
        {
        }

        /// <summary>
        /// 配置中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
        }

        /// <summary>
        /// 配置MVC功能
        /// </summary>
        /// <param name="mvcOptions"></param>
        public void ConfigureMvc(MvcOptions mvcOptions)
        {

        }
    }
}
