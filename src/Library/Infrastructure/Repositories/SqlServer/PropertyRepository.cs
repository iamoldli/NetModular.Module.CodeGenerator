using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.CodeGenerator.Domain.Enum;
using NetModular.Module.CodeGenerator.Domain.Property;
using NetModular.Module.CodeGenerator.Domain.Property.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SqlServer
{
    public class PropertyRepository : RepositoryAbstract<PropertyEntity>, IPropertyRepository
    {
        public PropertyRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<PropertyEntity>> Query(PropertyQueryModel model)
        {
            var paging = model.Paging();
            var query = Db.Find(m => m.ClassId == model.ClassId);
            query.WhereNotNull(model.Name, m => m.Name.Contains(model.Name) || m.Remarks.Contains(model.Name));

            var joinQuery = query.LeftJoin<AccountEntity>((x, y) => x.CreatedBy == y.Id)
                .LeftJoin<EnumEntity>((x, y, z) => x.EnumId == z.Id);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderBy((x, y, z) => x.Sort);
                joinQuery.OrderByDescending((x, y, z) => x.IsInherit);
            }

            joinQuery.Select((x, y, z) => new { x, Creator = y.Name, EnumName = z.Name });

            var list = await joinQuery.PaginationAsync(paging);
            model.TotalCount = paging.TotalCount;
            return list;
        }

        public Task<IList<PropertyEntity>> QueryByClass(Guid classId)
        {
            return Db.Find(m => m.ClassId == classId).OrderBy(m => m.Sort).ToListAsync();
        }

        public Task<bool> Exists(PropertyEntity entity)
        {
            return Db.Find(m => m.ClassId == entity.ClassId && m.Name.Equals(entity.Name))
                .WhereNotEmpty(entity.Id, m => m.Id != entity.Id)
                .ExistsAsync();
        }

        public Task<bool> ExistsByEnum(Guid enumId)
        {
            return Db.Find(m => m.EnumId == enumId).ExistsAsync();
        }

        public Task<bool> DeleteByClass(Guid classId, IUnitOfWork uow)
        {
            return Db.Find(m => m.ClassId == classId).UseUow(uow).DeleteAsync();
        }

        public Task<bool> DeleteByModule(Guid moduleId, IUnitOfWork uow)
        {
            return Db.Find(m => m.ModuleId == moduleId).UseUow(uow).DeleteAsync();
        }
    }
}
