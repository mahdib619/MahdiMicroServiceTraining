using DomainHelpers.Common;

namespace Financial.Domain.Entities;

public class CourseFee : EntityBase
{
    public string CourseCode { get; set; }
    public decimal Fee { get; set; }
}
