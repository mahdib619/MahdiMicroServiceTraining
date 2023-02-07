using MediatR;

namespace University.Application.Features.Majors.Commands.UpdateMajor;

public class UpdateMajorCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
