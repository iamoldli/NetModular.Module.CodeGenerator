using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SQLite
{
    public class ClassMethodRepository : SqlServer.ClassMethodRepository
    {
        public ClassMethodRepository(IDbContext context) : base(context)
        {
        }
    }
}
