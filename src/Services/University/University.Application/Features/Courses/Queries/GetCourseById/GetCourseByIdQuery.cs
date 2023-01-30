using MediatR;
using University.Application.Dtos.Course;

namespace University.Application.Features.Courses.Queries.GetCourseById;

public class GetCourseByIdQuery : IRequest<GetCourseDto>
{
    public int CourseId { get; set; }
}
