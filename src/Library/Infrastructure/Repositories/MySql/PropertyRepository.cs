using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.MySql
{
    public class PropertyRepository : SqlServer.PropertyRepository
    {
        public PropertyRepository(IDbContext context) : base(context)
        {
        }
    }
}
