using DomainHelpers.Common;

namespace University.Domain.Entities;

public class StudentCourse : EntityBase
{
    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int TermId { get; set; }
    public Term Term { get; set; }

    public bool IsPassed { get; set; }
    public bool IsDeleted { get; set; }
}
