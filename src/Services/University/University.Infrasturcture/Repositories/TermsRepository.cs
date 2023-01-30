using University.Application.Contracts.Persistence;
using University.Domain.Entities;
using University.Infrasturcture.Persistence;

namespace University.Infrasturcture.Repositories;

internal class TermsRepository : RepositoryBase<Term>, ITermsRepository
{
    public TermsRepository(UniDbContext dbContext) : base(dbContext)
    {
    }
}
