using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.CodeGenerator.Domain.OnlineModule;
using NetModular.Module.CodeGenerator.Domain.OnlineModule.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SqlServer
{
    public class OnlineModuleRepository : RepositoryAbstract<OnlineModuleEntity>, IOnlineModuleRepository
    {
        public OnlineModuleRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<OnlineModuleEntity>> Query(OnlineModuleQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();

            if (!paging.OrderBy.Any())
            {
                query.OrderByDescending(m => m.Id);
            }

            var result = await query.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
