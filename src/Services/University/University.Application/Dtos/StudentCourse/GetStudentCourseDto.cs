namespace University.Application.Dtos.StudentCourse;

public class GetStudentCourseDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int TermId { get; set; }
    public bool IsPassed { get; set; }
    public bool IsDeleted { get; set; }
}
