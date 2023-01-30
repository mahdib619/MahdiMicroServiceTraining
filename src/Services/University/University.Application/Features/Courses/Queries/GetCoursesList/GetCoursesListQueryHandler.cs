using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Course;

namespace University.Application.Features.Courses.Queries.GetCoursesList;

internal class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, List<GetCourseDto>>
{
    private readonly ICoursesRepository _repository;
    private readonly IMapper _mapper;

    public GetCoursesListQueryHandler(ICoursesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetCourseDto>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
    {
        var allCourses = await _repository.GetAllAsync();
        return _mapper.Map<List<GetCourseDto>>(allCourses);
    }
}
