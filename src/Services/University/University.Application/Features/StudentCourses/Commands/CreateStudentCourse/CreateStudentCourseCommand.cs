using MediatR;
using University.Application.Dtos.StudentCourse;

namespace University.Application.Features.StudentCourses.Commands.CreateStudentCourse;

public class CreateStudentCourseCommand : IRequest<GetStudentCourseDto>
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int TermId { get; set; }
}
