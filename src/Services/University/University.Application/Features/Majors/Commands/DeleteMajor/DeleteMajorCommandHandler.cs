using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Exceptions;
using University.Domain.Entities;

namespace University.Application.Features.Majors.Commands.DeleteMajor;

internal class DeleteMajorCommandHandler : IRequestHandler<DeleteMajorCommand>
{
    private readonly IMajorsRepository _repository;
    private readonly ILogger<DeleteMajorCommandHandler> _logger;

    public DeleteMajorCommandHandler(IMajorsRepository repository, ILogger<DeleteMajorCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteMajorCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _repository.DeleteAsync(request.MajorId);

        if (!deleted)
            throw new NotFoundException(nameof(Major), request.MajorId);

        _logger.LogInformation("Major {MajorId} is deleted successfully.", request.MajorId);

        return Unit.Value;
    }
}
