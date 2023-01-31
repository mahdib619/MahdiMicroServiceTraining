using MediatR;

namespace University.Application.Features.Students.Commands.UpdateStudent;

public class UpdateStudentCommand : IRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
