using MediatR;

namespace University.Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PracticalUnitsCount { get; set; }
    public int TheoricalUnitsCount { get; set; }
}
