using University.Domain.Common;

namespace University.Domain.Entities;

public class Student : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StudentNumber { get; set; }

    public int MajorId { get; set; }
    public Major Major { get; set; }

    public int SignUpTermId { get; set; }
    public Term SignUpTerm { get; set; }
}