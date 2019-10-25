using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.CodeGenerator.Domain.Enum;
using NetModular.Module.CodeGenerator.Domain.Enum.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SqlServer
{
    public class EnumRepository : RepositoryAbstract<EnumEntity>, IEnumRepository
    {
        public EnumRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<EnumEntity>> Query(EnumQueryModel model)
        {
            var paging = model.Paging();
            var query = Db.Find().WhereNotNull(model.Name, m => m.Name.Contains(model.Name));

            var joinQuery = query.LeftJoin<AccountEntity>((x, y) => x.CreatedBy == y.Id);
            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((x, y) => x.Id);
            }

            joinQuery.Select((x, y) => new { x, Creator = y.Name });

            var list = await joinQuery.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;
            return list;
        }

        public Task<bool> Exists(EnumEntity entity)
        {
            return Db.Find(m => m.Name.Equals(entity.Name))
                .WhereNotEmpty(entity.Id, m => m.Id != entity.Id)
                .ExistsAsync();
        }
    }
}
