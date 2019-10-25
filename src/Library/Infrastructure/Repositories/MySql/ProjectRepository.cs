using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.MySql
{
    public class ProjectRepository : SqlServer.ProjectRepository
    {
        public ProjectRepository(IDbContext context) : base(context)
        {
        }
    }
}
