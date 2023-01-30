using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Exception;
using University.Domain.Entities;

namespace University.Application.Features.Courses.Commands.DeleteCourse;

internal class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
{
    private readonly ICoursesRepository _repository;
    private readonly ILogger<DeleteCourseCommandHandler> _logger;

    public DeleteCourseCommandHandler(ICoursesRepository repository, ILogger<DeleteCourseCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _repository.DeleteAsync(request.CourseId);

        if (!deleted)
            throw new NotFoundException(nameof(Course), request.CourseId);

        _logger.LogInformation("Course {CourseId} is deleted successfully.", request.CourseId);

        return Unit.Value;
    }
}
