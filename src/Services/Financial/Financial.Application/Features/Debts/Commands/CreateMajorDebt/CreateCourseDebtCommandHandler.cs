using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.Debt;
using Financial.Application.Features.MajorFees.Queries.GetMajorFeeByMajorCode;
using Financial.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Financial.Application.Features.Debts.Commands.CreateMajorDebt;

internal class CreateMajorDebtCommandHandler : IRequestHandler<CreateMajorDebtCommand, GetDebtDto>
{
    private readonly IDebtsRepository _repository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateMajorDebtCommandHandler> _logger;

    public CreateMajorDebtCommandHandler(IDebtsRepository repository, IMediator mediator, IMapper mapper, ILogger<CreateMajorDebtCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<GetDebtDto> Handle(CreateMajorDebtCommand request, CancellationToken cancellationToken)
    {
        var debt = _mapper.Map<Debt>(request);

        var majorFee = await _mediator.Send(new GetMajorFeeByMajorCodeQuery { MajorCode = request.MajorCode }, cancellationToken);
        debt.Amount = majorFee.Fee;

        var debtDb = await _repository.AddAsync(debt);

        var response = _mapper.Map<GetDebtDto>(debtDb);

        _logger.LogInformation("New Debt:{@Debt} is added successfully.", response);

        return response;
    }
}
