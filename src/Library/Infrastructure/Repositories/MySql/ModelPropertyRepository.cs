using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.MySql
{
    public class ModelPropertyRepository : SqlServer.ModelPropertyRepository
    {
        public ModelPropertyRepository(IDbContext context) : base(context)
        {
        }
    }
}
