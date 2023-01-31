using MediatR;
using University.Application.Dtos.Student;

namespace University.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentCommand : IRequest<GetStudentDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StudentNumber { get; set; }
    public int SignUpTermId { get; set; }
}
