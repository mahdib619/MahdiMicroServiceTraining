using MediatR;

namespace University.Application.Features.Terms.Commands.DeleteTerm;

public class DeleteTermCommand : IRequest
{
    public int TermId { get; set; }
}
