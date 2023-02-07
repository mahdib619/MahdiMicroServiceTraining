using University.Application.Contracts.Persistence;
using University.Domain.Entities;
using University.Infrasturcture.Persistence;

namespace University.Infrasturcture.Repositories;

internal class MajorsRepository : RepositoryBase<Major>, IMajorsRepository
{
    public MajorsRepository(UniDbContext dbContext) : base(dbContext)
    {
    }
}
