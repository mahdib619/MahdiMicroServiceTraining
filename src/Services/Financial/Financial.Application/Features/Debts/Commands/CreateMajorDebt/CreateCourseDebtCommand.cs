using Financial.Application.Dtos.Debt;
using Financial.Domain.Entities;
using Financial.Domain.Enums;
using MediatR;

namespace Financial.Application.Features.Debts.Commands.CreateMajorDebt;

public class CreateMajorDebtCommand : IRequest<GetDebtDto>
{
    public string StudentNumber { get; set; }
    public string MajorCode { get; set; }
    public DateTime DateTime { get; set; }
    public string Description { get; set; }

    public Debt ToDebtEntity() => new()
    {
        StudentNumber = StudentNumber,
        SourceId = MajorCode,
        DebtSourseType = DebtSourseType.MajorTermFee,
        DateTime = DateTime,
        Description = Description
    };
}
