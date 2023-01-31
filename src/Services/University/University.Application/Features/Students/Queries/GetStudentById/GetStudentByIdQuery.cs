using MediatR;
using University.Application.Dtos.Student;

namespace University.Application.Features.Students.Queries.GetStudentById;

public class GetStudentByIdQuery : IRequest<GetStudentDto>
{
    public int StudentId { get; set; }
}
