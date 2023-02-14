namespace University.Application.Dtos.Student;

public class GetStudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StudentNumber { get; set; }
    public int MajorId { get; set; }
    public int SignUpTermId { get; set; }
}
