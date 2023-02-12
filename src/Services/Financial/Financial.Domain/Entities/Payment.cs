using DomainHelpers.Common;

namespace Financial.Domain.Entities;

public class Payment : EntityBase
{
    public string StudentNumber { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentTime { get; set; }
    public bool IsSuccess { get; set; }
    public string Description { get; set; }
}
