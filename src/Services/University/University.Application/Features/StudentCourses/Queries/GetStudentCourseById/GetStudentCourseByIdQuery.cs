using MediatR;
using University.Application.Dtos.StudentCourse;

namespace University.Application.Features.StudentCourses.Queries.GetStudentCourseById;

public class GetStudentCourseByIdQuery : IRequest<GetStudentCourseDto>
{
    public int StudentCourseId { get; set; }
}
