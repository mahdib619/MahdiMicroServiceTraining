using MediatR;

namespace Financial.Application.Features.Debts.Commands.DeleteLastStudentDebt;

public class DeleteLastStudentDebtCommand : IRequest
{
    public DeleteLastStudentDebtCommand(string studentNumber, string sourceId = null)
    {
        StudentNumber = studentNumber;
        SourceId = sourceId;
    }

    public string StudentNumber { get; }
    public string SourceId { get; }
}
