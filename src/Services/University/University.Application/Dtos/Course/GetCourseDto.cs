namespace University.Application.Dtos.Course;

public class GetCourseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int PracticalUnitsCount { get; set; }
    public int TheoricalUnitsCount { get; set; }
}
