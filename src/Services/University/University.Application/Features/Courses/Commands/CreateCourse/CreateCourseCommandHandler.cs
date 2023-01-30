using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Course;
using University.Domain.Entities;

namespace University.Application.Features.Courses.Commands.CreateCourse;

internal class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, GetCourseDto>
{
    private readonly ICoursesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCourseCommandHandler> _logger;

    public CreateCourseCommandHandler(ICoursesRepository repository, IMapper mapper, ILogger<CreateCourseCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetCourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<Course>(request);
        var addedCourse = await _repository.AddAsync(course);

        var courseRes = _mapper.Map<GetCourseDto>(addedCourse);

        _logger.LogInformation("New Course:{@Course} is added successfully.", courseRes);

        return courseRes;
    }
}
