using DataAccessHelper.Abstraction.Repositories;
using University.Domain.Entities;

namespace University.Application.Contracts.Persistence;

public interface ICoursesRepository : IAsyncRepository<Course>
{
}
