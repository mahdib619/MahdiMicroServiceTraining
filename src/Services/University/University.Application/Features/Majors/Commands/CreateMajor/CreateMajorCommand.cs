using MediatR;
using University.Application.Dtos.Major;

namespace University.Application.Features.Majors.Commands.CreateMajor;

public class CreateMajorCommand : IRequest<GetMajorDto>
{
    public string Name { get; set; }
    public string Code { get; set; }
}
