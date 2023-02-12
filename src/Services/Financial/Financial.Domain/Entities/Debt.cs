using DomainHelpers.Common;
using Financial.Domain.Enums;

namespace Financial.Domain.Entities;

public class Debt : EntityBase
{
    public string StudentNumber { get; set; }
    public string SourceId { get; set; }
    public decimal Amount { get; set; }
    public DebtSourseType DebtSourseType { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsDeleted { get; set; }
    public string Description { get; set; }
}