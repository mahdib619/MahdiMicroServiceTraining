using MediatR;
using University.Application.Dtos.Course;

namespace University.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommand : IRequest<GetCourseDto>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int PracticalUnitsCount { get; set; }
    public int TheoricalUnitsCount { get; set; }
}
