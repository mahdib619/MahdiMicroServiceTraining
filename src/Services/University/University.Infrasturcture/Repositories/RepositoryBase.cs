using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using University.Application.Contracts.Persistence;
using University.Domain.Common;
using University.Infrasturcture.Persistence;

namespace University.Infrasturcture.Repositories;

internal class RepositoryBase<TEntity> : IAsyncRepository<TEntity> where TEntity : EntityBase
{
    protected UniDbContext DbContext { get; }
    private readonly DbSet<TEntity> _entities;

    public RepositoryBase(UniDbContext dbContext)
    {
        DbContext = dbContext;
        _entities = DbContext.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await _entities.AsNoTracking()
                              .ToListAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.AsNoTracking()
                              .Where(predicate)
                              .ToListAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeString = null,
        bool disableTracking = true)
    {
        var query = _entities.AsQueryable();

        if (disableTracking)
            query = query.AsNoTracking();

        if (predicate is not null)
            query = query.Where(predicate);

        if (orderBy is not null)
            query = orderBy(query);

        if (includeString is not null)
            query = query.Include(includeString);

        return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        List<Expression<Func<TEntity, object>>> includes = null,
        bool disableTracking = true)
    {
        var query = _entities.AsQueryable();

        if (disableTracking)
            query = query.AsNoTracking();

        if (predicate is not null)
            query = query.Where(predicate);

        if (orderBy is not null)
            query = orderBy(query);

        if (includes is not null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _entities.AsNoTracking()
                              .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _entities.AddAsync(entity);
        await DbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _entities.Update(entity);
        var result = await DbContext.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _entities.Remove(entity);
        var result = await DbContext.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _entities.Where(e => e.Id == id)
                                    .ExecuteDeleteAsync();
        return result > 0;
    }
}
