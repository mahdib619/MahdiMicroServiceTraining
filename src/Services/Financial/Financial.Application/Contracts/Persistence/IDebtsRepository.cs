using Financial.Domain.Entities;

namespace Financial.Application.Contracts.Persistence;

public interface IDebtsRepository : IAsyncRepository<Debt>
{
}
