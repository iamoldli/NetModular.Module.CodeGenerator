using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.PostgreSQL
{
    public class ClassRepository : SqlServer.ClassRepository
    {
        public ClassRepository(IDbContext context) : base(context)
        {
        }
    }
}
