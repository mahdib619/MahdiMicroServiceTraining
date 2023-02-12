using DomainHelpers.Common;

namespace Financial.Domain.Entities;

public class MajorFee : EntityBase
{
    public string MajorCode { get; set; }
    public decimal Fee { get; set; }
}
