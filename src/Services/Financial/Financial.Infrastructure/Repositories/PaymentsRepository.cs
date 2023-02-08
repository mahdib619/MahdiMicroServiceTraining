using Financial.Application.Contracts.Persistence;
using Financial.Domain.Entities;
using Financial.Infrastructure.Persistence;

namespace Financial.Infrastructure.Repositories;

internal class PaymentsRepository : RepositoryBase<Payment>, IPaymentsRepository
{
    public PaymentsRepository(FinancialDbContext dbContext) : base(dbContext)
    {
    }
}
