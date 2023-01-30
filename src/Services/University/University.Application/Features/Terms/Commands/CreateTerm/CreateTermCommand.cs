using MediatR;
using University.Application.Dtos.Term;

namespace University.Application.Features.Terms.Commands.CreateTerm;

public class CreateTermCommand : IRequest<GetTermDto>
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
