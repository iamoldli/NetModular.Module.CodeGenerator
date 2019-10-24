using Microsoft.Extensions.Hosting;
using Nm.Lib.Host.Web;

namespace Nm.Module.Common.WebHost
{
    public class Startup : StartupAbstract
    {
        public Startup(IHostEnvironment env) : base(env)
        {
        }
    }
}
