using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Exception;
using University.Domain.Entities;

namespace University.Application.Features.StudentCourses.Commands.DeleteStudentCourse;

internal class DeleteStudentCourseCommandHandler : IRequestHandler<DeleteStudentCourseCommand>
{
    private readonly IStudentCoursesRepository _repository;
    private readonly ILogger<DeleteStudentCourseCommandHandler> _logger;

    public DeleteStudentCourseCommandHandler(IStudentCoursesRepository repository, ILogger<DeleteStudentCourseCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _repository.DeleteAsync(request.StudentCourseId);

        if (!deleted)
            throw new NotFoundException(nameof(StudentCourse), request.StudentCourseId);

        _logger.LogInformation("StudentCourse {StudentCourseId} is deleted successfully.", request.StudentCourseId);

        return Unit.Value;
    }
}
