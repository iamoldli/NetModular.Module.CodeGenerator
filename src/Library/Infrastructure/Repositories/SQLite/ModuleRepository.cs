using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SQLite
{
    public class ModuleRepository : SqlServer.ModuleRepository
    {
        public ModuleRepository(IDbContext context) : base(context)
        {
        }
    }
}
