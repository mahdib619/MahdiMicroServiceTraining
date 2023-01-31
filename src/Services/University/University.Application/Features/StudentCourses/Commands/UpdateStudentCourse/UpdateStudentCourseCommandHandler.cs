using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Exception;

namespace University.Application.Features.StudentCourses.Commands.UpdateStudentCourse;

internal class UpdateStudentCourseCommandHandler : IRequestHandler<UpdateStudentCourseCommand>
{
    private readonly IStudentCoursesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateStudentCourseCommandHandler> _logger;

    public UpdateStudentCourseCommandHandler(IStudentCoursesRepository repository, IMapper mapper, ILogger<UpdateStudentCourseCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateStudentCourseCommand request, CancellationToken cancellationToken)
    {
        var studentCourse = await _repository.GetByIdAsync(request.Id);

        if (studentCourse is null)
            throw new NotFoundException(nameof(studentCourse), request.Id);

        _mapper.Map(request, studentCourse);

        await _repository.UpdateAsync(studentCourse);

        _logger.LogInformation("StudentCourse {StudentCourseId} is updated successfully.", request.Id);

        return Unit.Value;
    }
}
