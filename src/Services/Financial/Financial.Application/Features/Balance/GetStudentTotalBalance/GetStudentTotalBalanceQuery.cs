using Financial.Application.Dtos.Balance;
using MediatR;

namespace Financial.Application.Features.Balance.GetStudentTotalBalance;

public class GetStudentTotalBalanceQuery : IRequest<GetTotalBalanceDto>
{
    public GetStudentTotalBalanceQuery(string studentNumber, DateTime? startDate = null, DateTime? endDate = null)
    {
        StudentNumber = studentNumber;
        StartDate = startDate ?? DateTime.MinValue;
        EndDate = endDate ?? DateTime.MaxValue;
    }

    public string StudentNumber { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
}
