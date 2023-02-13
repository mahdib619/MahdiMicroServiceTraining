using DataAccessHelper.EntityFramework.Repositories;
using DomainHelpers.Common;
using University.Infrasturcture.Persistence;

namespace University.Infrasturcture.Repositories;

internal class RepositoryBase<TEntity> : RelationalEFRepositoryBase<UniDbContext, TEntity> where TEntity : EntityBase
{
    public RepositoryBase(UniDbContext dbContext) : base(dbContext)
    {
    }
}