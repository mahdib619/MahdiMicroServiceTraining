using Financial.Domain.Entities;

namespace Financial.Application.Contracts.Persistence;

public interface IMajorFeesRepository : IAsyncRepository<MajorFee>
{
}
