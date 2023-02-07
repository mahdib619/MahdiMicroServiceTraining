using Financial.Domain.Entities;

namespace Financial.Application.Contracts.Persistence;

public interface IPaymentsRepository : IAsyncRepository<Payment>
{
}
