using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.PostgreSQL
{
    public class ClassMethodRepository : SqlServer.ClassMethodRepository
    {
        public ClassMethodRepository(IDbContext context) : base(context)
        {
        }
    }
}
