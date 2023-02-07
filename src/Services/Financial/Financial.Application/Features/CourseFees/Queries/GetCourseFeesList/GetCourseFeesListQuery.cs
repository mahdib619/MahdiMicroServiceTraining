using Financial.Application.Dtos.CourseFee;
using MediatR;

namespace Financial.Application.Features.CourseFees.Queries.GetCourseFeesList;

public class GetCourseFeesListQuery : IRequest<List<GetCourseFeeDto>>
{
}
