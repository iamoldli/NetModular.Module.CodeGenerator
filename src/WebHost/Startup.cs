using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NetModular.Lib.Host.Web;

namespace NetModular.Module.CodeGenerator.WebHost
{
    public class Startup : StartupAbstract
    {
        public Startup(IHostEnvironment env, IConfiguration cfg) : base(env, cfg)
        {
        }
    }
}
