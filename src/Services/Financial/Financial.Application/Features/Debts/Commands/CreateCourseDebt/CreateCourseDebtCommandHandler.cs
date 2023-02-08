using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.Debt;
using Financial.Application.Features.CourseFees.Queries.GetCourseFeeByCourseId;
using Financial.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Financial.Application.Features.Debts.Commands.CreateCourseDebt;

internal class CreateCourseDebtCommandHandler : IRequestHandler<CreateCourseDebtCommand, GetDebtDto>
{
    private readonly IDebtsRepository _repository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCourseDebtCommandHandler> _logger;

    public CreateCourseDebtCommandHandler(IDebtsRepository repository, IMediator mediator, IMapper mapper, ILogger<CreateCourseDebtCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<GetDebtDto> Handle(CreateCourseDebtCommand request, CancellationToken cancellationToken)
    {
        var debt = _mapper.Map<Debt>(request);

        var courseFee = await _mediator.Send(new GetCourseFeeByCourseIdQuery { CourseId = request.CourseId }, cancellationToken);
        debt.Amount = courseFee.Fee;

        var debtDb = await _repository.AddAsync(debt);

        var response = _mapper.Map<GetDebtDto>(debtDb);

        _logger.LogInformation("New Debt:{@Debt} is added successfully.", response);

        return response;
    }
}
