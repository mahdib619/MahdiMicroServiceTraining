using Financial.Application.Dtos.CourseFee;
using MediatR;

namespace Financial.Application.Features.CourseFees.Queries.GetCourseFeeByCourseId;

public class GetCourseFeeByCourseIdQuery : IRequest<GetCourseFeeDto>
{
    public int CourseId { get; set; }
}
