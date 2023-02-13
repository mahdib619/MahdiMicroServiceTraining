using DataAccessHelper.EntityFramework.Repositories;
using DomainHelpers.Common;
using Financial.Infrastructure.Persistence;

namespace Financial.Infrastructure.Repositories;

internal class RepositoryBase<TEntity> : RelationalEFRepositoryBase<FinancialDbContext, TEntity> where TEntity : EntityBase
{
    public RepositoryBase(FinancialDbContext dbContext) : base(dbContext)
    {
    }
}