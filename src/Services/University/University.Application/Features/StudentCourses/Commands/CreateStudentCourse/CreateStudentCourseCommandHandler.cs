using AutoMapper;
using GeneralHelpers.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.StudentCourse;
using University.Domain.Entities;

namespace University.Application.Features.StudentCourses.Commands.CreateStudentCourse;

internal class CreateStudentCourseCommandHandler : IRequestHandler<CreateStudentCourseCommand, GetStudentCourseDto>
{
    private readonly IStudentCoursesRepository _repository;
    private readonly IStudentsRepository _studentsRepository;
    private readonly ICoursesRepository _coursesRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateStudentCourseCommandHandler> _logger;

    public CreateStudentCourseCommandHandler(IStudentCoursesRepository repository,
        IStudentsRepository studentsRepository,
        ICoursesRepository coursesRepository,
        IMapper mapper,
        ILogger<CreateStudentCourseCommandHandler> logger)
    {
        _repository = repository;
        _studentsRepository = studentsRepository;
        _coursesRepository = coursesRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetStudentCourseDto> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
    {
        await CheckStudentCoursePersistedState(request);

        var studentCourse = _mapper.Map<StudentCourse>(request);
        var addedStudentCourse = await _repository.AddAsync(studentCourse);

        var studentCourseRes = _mapper.Map<GetStudentCourseDto>(addedStudentCourse);

        _logger.LogInformation("New StudentCourse:{@StudentCourse} is added successfully.", studentCourseRes);

        return studentCourseRes;
    }

    private async Task CheckStudentCoursePersistedState(CreateStudentCourseCommand request)
    {
        await CheckCourseExistence(request);
        await CheckStudentExistence(request);
        await CheckStudentCourseExistence(request);
    }

    private async Task CheckStudentCourseExistence(CreateStudentCourseCommand request)
    {
        var exists = await _repository.AnyAsync(e => e.StudentId == request.StudentId && e.CourseId == request.CourseId &&
                                                     (e.IsPassed || (e.TermId == request.TermId && !e.IsDeleted)));

        if (exists)
            throw new ClientException("Student has already taken this course!");
    }

    private async Task CheckStudentExistence(CreateStudentCourseCommand request)
    {
        var exists = await _studentsRepository.AnyAsync(e => e.Id == request.StudentId);
        if (!exists)
            throw new ClientException("Invalid StudentId!");
    }

    private async Task CheckCourseExistence(CreateStudentCourseCommand request)
    {
        var exists = await _coursesRepository.AnyAsync(e => e.Id == request.CourseId);
        if (!exists)
            throw new ClientException("Invalid CourseId!");
    }
}
