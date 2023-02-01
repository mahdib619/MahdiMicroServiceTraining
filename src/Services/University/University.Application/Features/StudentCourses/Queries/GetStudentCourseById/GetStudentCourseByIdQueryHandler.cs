using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.StudentCourse;
using University.Application.Exceptions;

namespace University.Application.Features.StudentCourses.Queries.GetStudentCourseById;

internal class GetStudentCourseByIdQueryHandler : IRequestHandler<GetStudentCourseByIdQuery, GetStudentCourseDto>
{
    private readonly IStudentCoursesRepository _repository;
    private readonly IMapper _mapper;

    public GetStudentCourseByIdQueryHandler(IStudentCoursesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetStudentCourseDto> Handle(GetStudentCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var studentCourse = await _repository.GetByIdAsync(request.StudentCourseId);

        if (studentCourse is null)
            throw new NotFoundException(nameof(studentCourse), request.StudentCourseId);

        return _mapper.Map<GetStudentCourseDto>(studentCourse);
    }
}
