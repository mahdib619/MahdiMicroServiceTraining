using MediatR;

namespace University.Application.Features.Majors.Commands.DeleteMajor;

public class DeleteMajorCommand : IRequest
{
    public int MajorId { get; set; }
}
