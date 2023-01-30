using MediatR;
using University.Application.Dtos.Course;

namespace University.Application.Features.Courses.Queries.GetCoursesList;

public class GetCoursesListQuery : IRequest<List<GetCourseDto>>
{
}
