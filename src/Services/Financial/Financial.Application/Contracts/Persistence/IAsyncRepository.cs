using System.Linq.Expressions;
using DomainHelpers.Common;

namespace Financial.Application.Contracts.Persistence;

public interface IAsyncRepository<TEntity> where TEntity : EntityBase
{
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeString = null,
        bool disableTracking = true);
    Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        List<Expression<Func<TEntity, object>>> includes = null,
        bool disableTracking = true);
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<bool> DeleteAsync(int id);
}