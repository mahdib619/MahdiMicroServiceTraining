using Financial.Domain.Entities;
using System.Linq.Expressions;
using DataAccessHelper.Abstraction.Repositories;

namespace Financial.Application.Contracts.Persistence;

public interface IDebtsRepository : IAsyncRepository<Debt>
{
    public Task<Debt> GetLast(Expression<Func<Debt, bool>> predicate = null);
}
