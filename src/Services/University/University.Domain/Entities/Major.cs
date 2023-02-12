using DomainHelpers.Common;

namespace University.Domain.Entities;

public class Major : EntityBase
{
    public string Name { get; set; }
    public string Code { get; set; }
}
