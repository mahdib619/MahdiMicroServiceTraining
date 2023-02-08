using System.Linq.Expressions;
using Financial.Application.Contracts.Persistence;
using Financial.Domain.Entities;
using Financial.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Financial.Infrastructure.Repositories;

internal class DebtsRepository : RepositoryBase<Debt>, IDebtsRepository
{
    public DebtsRepository(FinancialDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Debt> GetLast(Expression<Func<Debt, bool>> predicate = null)
    {
        var debts = DbContext.Debts.AsNoTracking();

        if (predicate is not null)
            debts = debts.Where(predicate);

        return await debts.OrderByDescending(e => e.DateTime).FirstOrDefaultAsync();
    }
}
