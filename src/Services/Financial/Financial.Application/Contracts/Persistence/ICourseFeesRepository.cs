using DataAccessHelper.Abstraction.Repositories;
using Financial.Domain.Entities;

namespace Financial.Application.Contracts.Persistence;

public interface ICourseFeesRepository : IAsyncRepository<CourseFee>
{
}
