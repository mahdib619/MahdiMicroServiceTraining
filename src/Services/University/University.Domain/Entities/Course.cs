using DomainHelpers.Common;

namespace University.Domain.Entities;

public class Course : EntityBase
{
    public string Name { get; set; }
    public int PracticalUnitsCount { get; set; }
    public int TheoricalUnitsCount { get; set; }
}