using MediatR;
using University.Application.Dtos.Student;

namespace University.Application.Features.Students.Queries.GetStudentsList;

public class GetStudentsListQuery : IRequest<List<GetStudentDto>>
{
}
