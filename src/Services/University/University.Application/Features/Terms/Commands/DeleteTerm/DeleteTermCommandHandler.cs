using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Exception;
using University.Domain.Entities;

namespace University.Application.Features.Terms.Commands.DeleteTerm;

internal class DeleteTermCommandHandler : IRequestHandler<DeleteTermCommand>
{
    private readonly ITermsRepository _repository;
    private readonly ILogger<DeleteTermCommandHandler> _logger;

    public DeleteTermCommandHandler(ITermsRepository repository, ILogger<DeleteTermCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteTermCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _repository.DeleteAsync(request.TermId);

        if (!deleted)
            throw new NotFoundException(nameof(Term), request.TermId);

        _logger.LogInformation("Term {TermId} is deleted successfully.", request.TermId);

        return Unit.Value;
    }
}
