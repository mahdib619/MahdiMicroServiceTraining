using University.Application.Contracts.Persistence;
using University.Domain.Entities;
using University.Infrasturcture.Persistence;

namespace University.Infrasturcture.Repositories;

internal class StudentCoursesRepository : RepositoryBase<StudentCourse>, IStudentCoursesRepository
{
    public StudentCoursesRepository(UniDbContext dbContext) : base(dbContext)
    {
    }
}
