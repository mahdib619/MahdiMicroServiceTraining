using MediatR;
using University.Application.Dtos.Major;

namespace University.Application.Features.Majors.Queries.GetMajorsList;

public class GetMajorsListQuery : IRequest<List<GetMajorDto>>
{
}
