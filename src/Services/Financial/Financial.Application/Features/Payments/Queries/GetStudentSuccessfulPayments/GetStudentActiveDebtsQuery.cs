using Financial.Application.Dtos.Debt;
using MediatR;

namespace Financial.Application.Features.Payments.Queries.GetStudentSuccessfulPayments;

public class GetStudentSuccessFulPaymentsQuery : IRequest<List<GetDebtDto>>
{
    public GetStudentSuccessFulPaymentsQuery(string studentNumber, DateTime? startDate = null, DateTime? endDate = null)
    {
        StudentNumber = studentNumber;
        StartDate = startDate ?? DateTime.MinValue;
        EndDate = endDate ?? DateTime.MaxValue;
    }

    public string StudentNumber { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
}
