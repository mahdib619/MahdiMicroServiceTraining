using University.Application.Contracts.Persistence;
using University.Domain.Entities;
using University.Infrasturcture.Persistence;

namespace University.Infrasturcture.Repositories;

internal class StudentsRepository : RepositoryBase<Student>, IStudentsRepository
{
    public StudentsRepository(UniDbContext dbContext) : base(dbContext)
    {
    }
}
