using Financial.Domain.Enums;

namespace Financial.Application.Dtos.Debt;

public class GetDebtDto
{
    public string StudentNumber { get; set; }
    public string SourceId { get; set; }
    public decimal Amount { get; set; }
    public DebtSourseType DebtSourseType { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsDeleted { get; set; }
    public string Description { get; set; }
}
