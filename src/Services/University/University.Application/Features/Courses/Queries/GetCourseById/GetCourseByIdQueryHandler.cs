using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Course;
using University.Application.Exception;
using University.Domain.Entities;

namespace University.Application.Features.Courses.Queries.GetCourseById;

internal class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, GetCourseDto>
{
    private readonly ICoursesRepository _repository;
    private readonly IMapper _mapper;

    public GetCourseByIdQueryHandler(ICoursesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _repository.GetByIdAsync(request.CourseId);

        if (course is null)
            throw new NotFoundException(nameof(Course), request.CourseId);

        return _mapper.Map<GetCourseDto>(course);
    }
}
