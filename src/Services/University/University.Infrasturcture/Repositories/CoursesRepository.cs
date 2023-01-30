using University.Application.Contracts.Persistence;
using University.Domain.Entities;
using University.Infrasturcture.Persistence;

namespace University.Infrasturcture.Repositories;

internal class CoursesRepository : RepositoryBase<Course>, ICoursesRepository
{
    public CoursesRepository(UniDbContext dbContext) : base(dbContext)
    {
    }
}
