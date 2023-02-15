using GeneralHelpers.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
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
        var studentCourse = await _repository.GetByIdAsync(request.StudentCourseId);

        CheckStudentCourseExistence(studentCourse, request);
        CheckPassedState(studentCourse);

        studentCourse.IsDeleted = true;
        await _repository.UpdateAsync(studentCourse);

        _logger.LogInformation("StudentCourse {StudentCourseId} is deleted successfully.", request.StudentCourseId);

        return Unit.Value;
    }

    private static void CheckStudentCourseExistence(StudentCourse studentCourse, DeleteStudentCourseCommand request)
    {
        if (studentCourse is null)
            throw new NotFoundException(nameof(StudentCourse), request.StudentCourseId);
    }

    private static void CheckPassedState(StudentCourse studentCourse)
    {
        if (studentCourse.IsPassed)
            throw new ClientException("Cannot delete passed course!");
    }
}
