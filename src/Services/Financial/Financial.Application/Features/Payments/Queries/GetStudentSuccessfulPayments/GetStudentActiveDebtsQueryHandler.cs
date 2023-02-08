using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.Debt;
using MediatR;

namespace Financial.Application.Features.Payments.Queries.GetStudentSuccessfulPayments;

internal class GetStudentSuccessFulPaymentsQueryHandler : IRequestHandler<GetStudentSuccessFulPaymentsQuery, List<GetDebtDto>>
{
    private readonly IPaymentsRepository _repository;
    private readonly IMapper _mapper;

    public GetStudentSuccessFulPaymentsQueryHandler(IPaymentsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetDebtDto>> Handle(GetStudentSuccessFulPaymentsQuery request, CancellationToken cancellationToken)
    {
        var payments = await _repository.GetAsync(e => e.IsSuccess && e.StudentNumber == request.StudentNumber && e.PaymentTime >= request.StartDate && e.PaymentTime <= request.EndDate);
        return _mapper.Map<List<GetDebtDto>>(payments);
    }
}
