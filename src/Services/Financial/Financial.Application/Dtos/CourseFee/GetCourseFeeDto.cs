namespace Financial.Application.Dtos.CourseFee;

public class GetCourseFeeDto
{
    public int Id { get; set; }
    public string CourseCode { get; set; }
    public decimal Fee { get; set; }
}
