using System;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Module.CodeGenerator.Domain.ClassMethod;

namespace NetModular.Module.CodeGenerator.Infrastructure.Repositories.SqlServer
{
    public class ClassMethodRepository : RepositoryAbstract<ClassMethodEntity>, IClassMethodRepository
    {
        public ClassMethodRepository(IDbContext context) : base(context)
        {

        }

        public Task<bool> DeleteByClass(Guid classId, IUnitOfWork uow)
        {
            return Db.Find(m => m.ClassId == classId).UseUow(uow).DeleteAsync();
        }

        public Task<ClassMethodEntity> GetByClass(Guid classId, IUnitOfWork uow)
        {
            return Db.Find(m => m.ClassId == classId).UseUow(uow).FirstAsync();
        }
    }
}
