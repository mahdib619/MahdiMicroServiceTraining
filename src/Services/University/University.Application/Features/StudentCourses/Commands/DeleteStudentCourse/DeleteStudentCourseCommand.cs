using MediatR;

namespace University.Application.Features.StudentCourses.Commands.DeleteStudentCourse;

public class DeleteStudentCourseCommand : IRequest
{
    public int StudentCourseId { get; set; }
}
