using Financial.Domain.Common;

namespace Financial.Domain.Entities;

public class CourseFee : EntityBase
{
    public int CourseId { get; set; }
    public decimal Fee { get; set; }
}
