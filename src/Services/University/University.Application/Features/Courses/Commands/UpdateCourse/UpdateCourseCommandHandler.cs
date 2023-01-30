using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Exception;
using University.Domain.Entities;

namespace University.Application.Features.Courses.Commands.UpdateCourse;

internal class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
{
    private readonly ICoursesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCourseCommandHandler> _logger;

    public UpdateCourseCommandHandler(ICoursesRepository repository, IMapper mapper, ILogger<UpdateCourseCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<Course>(request);

        var updated = await _repository.UpdateAsync(course);

        if (!updated)
            throw new NotFoundException(nameof(Course), request.Id);

        _logger.LogInformation("Course {CourseId} is updated successfully.", request.Id);

        return Unit.Value;
    }
}
