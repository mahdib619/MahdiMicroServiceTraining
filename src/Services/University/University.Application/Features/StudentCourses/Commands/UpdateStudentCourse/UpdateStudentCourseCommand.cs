using MediatR;

namespace University.Application.Features.StudentCourses.Commands.UpdateStudentCourse;

public class UpdateStudentCourseCommand : IRequest
{
    public int Id { get; set; }
    public bool IsPassed { get; set; }
    public bool IsDeleted { get; set; }
}
