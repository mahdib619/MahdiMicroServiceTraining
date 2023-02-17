using Financial.Application.Dtos.CourseFee;
using MediatR;

namespace Financial.Application.Features.CourseFees.Queries.GetCourseFeeByCourseCode;

public class GetCourseFeeByCourseCodeQuery : IRequest<GetCourseFeeDto>
{
    public string CourseCode { get; set; }
}
