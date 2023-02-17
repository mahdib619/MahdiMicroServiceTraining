using System.Linq.Expressions;
using EventBus.Messages.Events;
using GeneralHelpers.Exceptions;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Domain.Entities;

namespace University.Application.Features.StudentCourses.Commands.DeleteStudentCourse;

internal class DeleteStudentCourseCommandHandler : IRequestHandler<DeleteStudentCourseCommand>
{
    private readonly IStudentCoursesRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<DeleteStudentCourseCommandHandler> _logger;

    public DeleteStudentCourseCommandHandler(IStudentCoursesRepository repository, IPublishEndpoint publishEndpoint, ILogger<DeleteStudentCourseCommandHandler> logger)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
    {
        var studentCourse = await GetStudentCourse(request);

        CheckPassedState(studentCourse);

        studentCourse.IsDeleted = true;
        await _repository.UpdateAsync(studentCourse);

        await PublishDeletedCourseEvent(studentCourse);

        _logger.LogInformation("StudentCourse {StudentCourseId} is deleted successfully.", request.StudentCourseId);

        return Unit.Value;
    }

    private async Task<StudentCourse> GetStudentCourse(DeleteStudentCourseCommand request)
    {
        var studentCourseCol = await _repository.GetAsync(e => e.Id == request.StudentCourseId, null, new List<Expression<Func<StudentCourse, object>>> { e => e.Student.Major, e => e.Course });

        if (studentCourseCol.Count == 0)
            throw new NotFoundException(nameof(StudentCourse), request.StudentCourseId);

        return studentCourseCol[0];
    }

    private static void CheckPassedState(StudentCourse studentCourse)
    {
        if (studentCourse.IsPassed)
            throw new ClientException("Cannot delete passed course!");
    }

    private async Task PublishDeletedCourseEvent(StudentCourse studentCourse)
    {
        var message = new StudentDeletedCourseEvent
        {
            StudentNumber = studentCourse.Student.StudentNumber,
            MajorCode = studentCourse.Student.Major.Code,
            DeletedCourseCode = studentCourse.Course.Code
        };

        await _publishEndpoint.Publish(message);
    }
}
