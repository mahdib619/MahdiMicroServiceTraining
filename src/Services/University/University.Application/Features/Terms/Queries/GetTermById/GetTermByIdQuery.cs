using MediatR;
using University.Application.Dtos.Term;

namespace University.Application.Features.Terms.Queries.GetTermById;

public class GetTermByIdQuery : IRequest<GetTermDto>
{
    public int TermId { get; set; }
}
