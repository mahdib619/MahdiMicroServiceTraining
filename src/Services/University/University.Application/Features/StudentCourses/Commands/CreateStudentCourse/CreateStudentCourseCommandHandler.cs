using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.StudentCourse;
using University.Domain.Entities;

namespace University.Application.Features.StudentCourses.Commands.CreateStudentCourse;

internal class CreateStudentCourseCommandHandler : IRequestHandler<CreateStudentCourseCommand, GetStudentCourseDto>
{
    private readonly IStudentCoursesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateStudentCourseCommandHandler> _logger;

    public CreateStudentCourseCommandHandler(IStudentCoursesRepository repository, IMapper mapper, ILogger<CreateStudentCourseCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetStudentCourseDto> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
    {
        var studentCourse = _mapper.Map<StudentCourse>(request);
        var addedStudentCourse = await _repository.AddAsync(studentCourse);

        var studentCourseRes = _mapper.Map<GetStudentCourseDto>(addedStudentCourse);

        _logger.LogInformation("New StudentCourse:{@StudentCourse} is added successfully.", studentCourseRes);

        return studentCourseRes;
    }
}
