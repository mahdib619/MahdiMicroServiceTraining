using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.CourseFee;
using MediatR;

namespace Financial.Application.Features.CourseFees.Queries.GetCourseFeesList;

internal class GetCourseFeesListQueryHandler : IRequestHandler<GetCourseFeesListQuery, List<GetCourseFeeDto>>
{
    private readonly ICourseFeesRepository _repository;
    private readonly IMapper _mapper;

    public GetCourseFeesListQueryHandler(ICourseFeesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetCourseFeeDto>> Handle(GetCourseFeesListQuery request, CancellationToken cancellationToken)
    {
        var all = await _repository.GetAllAsync();
        return _mapper.Map<List<GetCourseFeeDto>>(all);
    }
}
