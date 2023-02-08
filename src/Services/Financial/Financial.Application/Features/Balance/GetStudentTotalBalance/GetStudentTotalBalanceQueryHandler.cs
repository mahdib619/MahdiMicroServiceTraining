using Financial.Application.Dtos.Balance;
using Financial.Application.Features.Debts.Queries.GetStudentActiveDebts;
using Financial.Application.Features.Payments.Queries.GetStudentSuccessfulPayments;
using MediatR;

namespace Financial.Application.Features.Balance.GetStudentTotalBalance;

internal class GetStudentTotalBalanceQueryHandler : IRequestHandler<GetStudentTotalBalanceQuery, GetTotalBalanceDto>
{
    private readonly IMediator _mediator;

    public GetStudentTotalBalanceQueryHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<GetTotalBalanceDto> Handle(GetStudentTotalBalanceQuery request, CancellationToken cancellationToken)
    {
        var payments = await _mediator.Send(new GetStudentSuccessFulPaymentsQuery(request.StudentNumber, request.StartDate, request.EndDate), cancellationToken);
        var debts = await _mediator.Send(new GetStudentActiveDebtsQuery(request.StudentNumber, request.StartDate, request.EndDate), cancellationToken);

        var totalBalance = payments.Sum(p => p.Amount) - debts.Sum(d => d.Amount);

        return new()
        {
            StudentNumber = request.StudentNumber,
            TotalBalance = totalBalance
        };
    }
}
