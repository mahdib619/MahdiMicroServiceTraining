using Financial.Application.Contracts.Persistence;
using Financial.Domain.Entities;
using Financial.Infrastructure.Persistence;

namespace Financial.Infrastructure.Repositories;

internal class MajorFeesRepository : RepositoryBase<MajorFee>, IMajorFeesRepository
{
    public MajorFeesRepository(FinancialDbContext dbContext) : base(dbContext)
    {
    }
}
