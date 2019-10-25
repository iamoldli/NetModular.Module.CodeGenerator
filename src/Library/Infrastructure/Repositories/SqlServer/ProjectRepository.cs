using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.CodeGenerator.Domain.Project;
using NetModular.Module.CodeGenerator.Domain.Project.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SqlServer
{
    public class ProjectRepository : RepositoryAbstract<ProjectEntity>, IProjectRepository
    {
        public ProjectRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<ProjectEntity>> Query(ProjectQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();
            query.WhereNotNull(model.Name, m => m.Name.Contains(model.Name));
            query.WhereNotNull(model.Code, m => m.Code.Contains(model.Code));

            var joinQuery = query.LeftJoin<AccountEntity>((x, y) => x.CreatedBy == y.Id);
            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((x, y) => x.Id);
            }

            joinQuery.Select((x, y) => new { x, Creator = y.Name });

            var result = await joinQuery.PaginationAsync(paging);
            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
