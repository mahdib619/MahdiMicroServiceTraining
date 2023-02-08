using Financial.Application.Contracts.Persistence;
using Financial.Domain.Entities;
using Financial.Infrastructure.Persistence;

namespace Financial.Infrastructure.Repositories;

internal class CourseFeesRepository : RepositoryBase<CourseFee>, ICourseFeesRepository
{
    public CourseFeesRepository(FinancialDbContext dbContext) : base(dbContext)
    {
    }
}
