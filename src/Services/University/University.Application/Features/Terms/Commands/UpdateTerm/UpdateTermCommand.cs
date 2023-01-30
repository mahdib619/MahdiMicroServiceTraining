using MediatR;

namespace University.Application.Features.Terms.Commands.UpdateTerm;

public class UpdateTermCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
