using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.CodeGenerator.Domain.ModelProperty;
using NetModular.Module.CodeGenerator.Domain.ModelProperty.Models;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SqlServer
{
    public class ModelPropertyRepository : RepositoryAbstract<ModelPropertyEntity>, IModelPropertyRepository
    {
        public ModelPropertyRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<ModelPropertyEntity>> Query(ModelPropertyQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find(m => m.ClassId == model.ClassId && m.ModelType == model.ModelType);

            var joinQuery = query.LeftJoin<AccountEntity>((x, y) => x.CreatedBy == y.Id)
                .LeftJoin<ModelPropertyEntity>((x, y, z) => x.EnumId == z.Id);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderBy((x, y, z) => x.Sort);
            }

            joinQuery.Select((x, y, z) => new { x, Creator = y.Name, EnumName = z.Name });

            var list = await joinQuery.PaginationAsync(paging);
            model.TotalCount = paging.TotalCount;
            return list;
        }

        public Task<IList<ModelPropertyEntity>> QueryAll(ModelPropertyQueryModel model)
        {
            return Db.Find(m => m.ClassId == model.ClassId && m.ModelType == model.ModelType).ToListAsync();
        }

        public Task<IList<ModelPropertyEntity>> QueryByClass(Guid classId)
        {
            return Db.Find(m => m.ClassId == classId).ToListAsync();
        }

        public Task<bool> Exists(ModelPropertyEntity entity)
        {
            var query = Db.Find(m => m.ClassId == entity.ClassId && m.ModelType == entity.ModelType && m.Name == entity.Name);
            query.WhereNotEmpty(entity.Id, m => m.Id != entity.Id);
            return query.ExistsAsync();
        }

        public Task<bool> DeleteByModule(Guid moduleId, IUnitOfWork uow)
        {
            return Db.Find(m => m.ModuleId == moduleId).UseUow(uow).DeleteAsync();
        }
    }
}
