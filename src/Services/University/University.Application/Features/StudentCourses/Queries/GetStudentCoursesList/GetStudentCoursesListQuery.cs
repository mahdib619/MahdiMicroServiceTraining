using MediatR;
using University.Application.Dtos.StudentCourse;

namespace University.Application.Features.StudentCourses.Queries.GetStudentCoursesList;

public class GetStudentCoursesListQuery : IRequest<List<GetStudentCourseDto>>
{
}
