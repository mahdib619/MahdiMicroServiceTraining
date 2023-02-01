using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Exceptions;
using University.Domain.Entities;

namespace University.Application.Features.Students.Commands.DeleteStudent;

internal class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
{
    private readonly IStudentsRepository _repository;
    private readonly ILogger<DeleteStudentCommandHandler> _logger;

    public DeleteStudentCommandHandler(IStudentsRepository repository, ILogger<DeleteStudentCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _repository.DeleteAsync(request.StudentId);

        if (!deleted)
            throw new NotFoundException(nameof(Student), request.StudentId);

        _logger.LogInformation("Student {StudentId} is deleted successfully.", request.StudentId);

        return Unit.Value;
    }
}
