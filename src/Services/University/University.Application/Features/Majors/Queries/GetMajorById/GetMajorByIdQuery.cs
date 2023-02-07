using MediatR;
using University.Application.Dtos.Major;

namespace University.Application.Features.Majors.Queries.GetMajorById;

public class GetMajorByIdQuery : IRequest<GetMajorDto>
{
    public int MajorId { get; set; }
}
