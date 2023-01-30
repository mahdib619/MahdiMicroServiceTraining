using MediatR;
using University.Application.Dtos.Term;

namespace University.Application.Features.Terms.Queries.GetTermsList;

public class GetTermsListQuery : IRequest<List<GetTermDto>>
{
}
