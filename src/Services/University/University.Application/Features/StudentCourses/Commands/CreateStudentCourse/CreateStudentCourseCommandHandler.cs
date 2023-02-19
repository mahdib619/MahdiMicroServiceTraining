using System.Linq.Expressions;
using AutoMapper;
using EventBus.Messages.Events;
using GeneralHelpers.Exceptions;
using MassTransit;
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
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateStudentCourseCommandHandler> _logger;

    public CreateStudentCourseCommandHandler(IStudentCoursesRepository repository,
        IStudentsRepository studentsRepository,
        ICoursesRepository coursesRepository,
        ITermsRepository termsRepository,
        IStudentBalanceDataClient studentBalanceDataClient,
        IPublishEndpoint publishEndpoint,
        IMapper mapper,
        ILogger<CreateStudentCourseCommandHandler> logger)
    {
        _repository = repository;
        _studentsRepository = studentsRepository;
        _coursesRepository = coursesRepository;
        _termsRepository = termsRepository;
        _studentBalanceDataClient = studentBalanceDataClient;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetStudentCourseDto> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
    {
        await CheckStudentCourseExistence(request);

        var term = await GetTerm(request);
        var course = await GetCourse(request);
        var student = await GetStudent(request);

        await CheckStudentBalance(student, term);

        var studentCourse = _mapper.Map<StudentCourse>(request);
        var addedStudentCourse = await _repository.AddAsync(studentCourse);

        await PublishPickedCourseEvent(request, student, course, addedStudentCourse.Id);

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

    private async Task<Course> GetCourse(CreateStudentCourseCommand request)
    {
        var course = await _coursesRepository.GetByIdAsync(request.CourseId);

        if (course is null)
            throw new ClientException("Invalid CourseId!");

        return course;
    }

    private async Task CheckStudentBalance(Student student, Term term)
    {
        var balance = await _studentBalanceDataClient.GetStudentBalanceInfo(student.StudentNumber, null, term.StartDate.AddDays(-1));

        if (balance.IsDebtor)
            throw new ClientException("Student has debt!");
    }

    private async Task<Student> GetStudent(CreateStudentCourseCommand request)
    {
        var studentColl = await _studentsRepository.GetAsync(e => e.Id == request.StudentId, null, new List<Expression<Func<Student, object>>> { e => e.Major });

        if (studentColl.Count == 0)
            throw new ClientException("Invalid StudentId!");

        return studentColl[0];
    }

    private async Task<Term> GetTerm(CreateStudentCourseCommand request)
    {
        var term = await _termsRepository.GetByIdAsync(request.TermId);

        if (term is null)
            throw new ClientException("Invalid TermId!");

        return term;
    }

    private async Task PublishPickedCourseEvent(CreateStudentCourseCommand request, Student student, Course course, int newStudentCourseId)
    {
        var message = new StudentPickedCourseEvent
        {
            StudentNumber = student.StudentNumber,
            MajorCode = student.Major.Code,
            PickedCourseCode = course.Code,
            IsFirstPickedCoursInTerm = await _repository.AnyAsync(e => e.Id != newStudentCourseId && e.StudentId == student.Id && e.TermId == request.TermId) == false
        };

        await _publishEndpoint.Publish(message);
    }
}
