using University.Domain.Common;

namespace University.Domain.Entities;

public class Term : EntityBase
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}