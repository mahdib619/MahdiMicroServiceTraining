using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.StudentCourse;

namespace University.Application.Features.StudentCourses.Queries.GetStudentCoursesList;

internal class GetStudentCoursesListQueryHandler : IRequestHandler<GetStudentCoursesListQuery, List<GetStudentCourseDto>>
{
    private readonly IStudentCoursesRepository _repository;
    private readonly IMapper _mapper;

    public GetStudentCoursesListQueryHandler(IStudentCoursesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetStudentCourseDto>> Handle(GetStudentCoursesListQuery request, CancellationToken cancellationToken)
    {
        var allStudentCourses = await _repository.GetAllAsync();
        return _mapper.Map<List<GetStudentCourseDto>>(allStudentCourses);
    }
}
