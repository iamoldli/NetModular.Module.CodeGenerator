using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SQLite
{
    public class OnlineModuleRepository : SqlServer.OnlineModuleRepository
    {
        public OnlineModuleRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
