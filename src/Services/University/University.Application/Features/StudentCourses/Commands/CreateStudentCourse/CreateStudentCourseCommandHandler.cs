using AutoMapper;
using GeneralHelpers.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Contracts.SyncDataServices;
using University.Application.Dtos.StudentCourse;
using University.Domain.Entities;

namespace University.Application.Features.StudentCourses.Commands.CreateStudentCourse;

internal class CreateStudentCourseCommandHandler : IRequestHandler<CreateStudentCourseCommand, GetStudentCourseDto>
{
    private readonly IStudentCoursesRepository _repository;
    private readonly IStudentsRepository _studentsRepository;
    private readonly ICoursesRepository _coursesRepository;
    private readonly ITermsRepository _termsRepository;
    private readonly IStudentBalanceDataClient _studentBalanceDataClient;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateStudentCourseCommandHandler> _logger;

    public CreateStudentCourseCommandHandler(IStudentCoursesRepository repository,
        IStudentsRepository studentsRepository,
        ICoursesRepository coursesRepository,
        ITermsRepository termsRepository,
        IStudentBalanceDataClient studentBalanceDataClient,
        IMapper mapper,
        ILogger<CreateStudentCourseCommandHandler> logger)
    {
        _repository = repository;
        _studentsRepository = studentsRepository;
        _coursesRepository = coursesRepository;
        _termsRepository = termsRepository;
        _studentBalanceDataClient = studentBalanceDataClient;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetStudentCourseDto> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
    {
        await CheckCourseExistence(request);
        await CheckStudentCourseExistence(request);
        await CheckStudentBalance(await GetStudent(request), await GetTerm(request));

        var studentCourse = _mapper.Map<StudentCourse>(request);
        var addedStudentCourse = await _repository.AddAsync(studentCourse);

        var studentCourseRes = _mapper.Map<GetStudentCourseDto>(addedStudentCourse);

        _logger.LogInformation("New StudentCourse:{@StudentCourse} is added successfully.", studentCourseRes);

        return studentCourseRes;
    }

    private async Task CheckStudentCourseExistence(CreateStudentCourseCommand request)
    {
        var exists = await _repository.AnyAsync(e => e.StudentId == request.StudentId && e.CourseId == request.CourseId &&
                                                     (e.IsPassed || (e.TermId == request.TermId && !e.IsDeleted)));

        if (exists)
            throw new ClientException("Student has already taken this course!");
    }

    private async Task CheckCourseExistence(CreateStudentCourseCommand request)
    {
        var exists = await _coursesRepository.AnyAsync(e => e.Id == request.CourseId);
        if (!exists)
            throw new ClientException("Invalid CourseId!");
    }

    private async Task CheckStudentBalance(Student student, Term term)
    {
        var balance = await _studentBalanceDataClient.GetStudentBalanceInfo(student.StudentNumber, null, term.StartDate.AddDays(-1));

        if (balance.IsDebtor)
            throw new ClientException("Student has debt!");
    }

    private async Task<Student> GetStudent(CreateStudentCourseCommand request)
    {
        var student = await _studentsRepository.GetByIdAsync(request.StudentId);

        if (student is null)
            throw new ClientException("Invalid StudentId!");

        return student;
    }

    private async Task<Term> GetTerm(CreateStudentCourseCommand request)
    {
        var term = await _termsRepository.GetByIdAsync(request.TermId);

        if (term is null)
            throw new ClientException("Invalid TermId!");

        return term;
    }
}
