using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.Payment;
using Financial.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Financial.Application.Features.Payments.Commands.CreatePayment;

internal class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, GetPaymentDto>
{
    private readonly IPaymentsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreatePaymentCommandHandler> _logger;

    public CreatePaymentCommandHandler(IPaymentsRepository repository, IMapper mapper, ILogger<CreatePaymentCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetPaymentDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = _mapper.Map<Payment>(request);
        var paymentDb = await _repository.AddAsync(payment);

        var response = _mapper.Map<GetPaymentDto>(paymentDb);

        _logger.LogInformation("New Payment:{@Payment} is added successfully.", response);

        return response;
    }
}
