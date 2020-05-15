using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.PostgreSQL
{
    public class EnumRepository : SqlServer.EnumRepository
    {
        public EnumRepository(IDbContext context) : base(context)
        {
        }
    }
}
