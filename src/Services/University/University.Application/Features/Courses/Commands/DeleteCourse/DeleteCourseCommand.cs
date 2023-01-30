using MediatR;

namespace University.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommand : IRequest
{
    public int CourseId { get; set; }
}
