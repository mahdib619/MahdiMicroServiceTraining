using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Exceptions;
using Financial.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Financial.Application.Features.Debts.Commands.DeleteLastStudentDebt;

internal class DeleteLastStudentDebtCommandHandler : IRequestHandler<DeleteLastStudentDebtCommand>
{
    private readonly IDebtsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteLastStudentDebtCommandHandler> _logger;

    public DeleteLastStudentDebtCommandHandler(IDebtsRepository repository, IMapper mapper, ILogger<DeleteLastStudentDebtCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteLastStudentDebtCommand request, CancellationToken cancellationToken)
    {
        var debt = await _repository.GetLast(e => !e.IsDeleted && e.StudentNumber == request.StudentNumber && (request.SourceId == null || e.SourceId == request.SourceId));

        if (debt is null)
            throw new NotFoundException($"""Could not found an active entity "{nameof(Debt)}" with (StudentNumber: {request.StudentNumber}, SourceId: {request.SourceId})!""");

        debt.IsDeleted = true;
        await _repository.UpdateAsync(debt);

        _logger.LogInformation("Debt {DebtId} is deleted successfully.", debt.Id);

        return Unit.Value;
    }
}
