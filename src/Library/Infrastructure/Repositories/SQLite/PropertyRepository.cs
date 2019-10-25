using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SQLite
{
    public class PropertyRepository : SqlServer.PropertyRepository
    {
        public PropertyRepository(IDbContext context) : base(context)
        {
        }
    }
}
