using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.MySql
{
    public class EnumItemRepository : SqlServer.EnumItemRepository
    {
        public EnumItemRepository(IDbContext context) : base(context)
        {
        }
    }
}
