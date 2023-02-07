using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Major;

namespace University.Application.Features.Majors.Queries.GetMajorsList;

internal class GetMajorsListQueryHandler : IRequestHandler<GetMajorsListQuery, List<GetMajorDto>>
{
    private readonly IMajorsRepository _repository;
    private readonly IMapper _mapper;

    public GetMajorsListQueryHandler(IMajorsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetMajorDto>> Handle(GetMajorsListQuery request, CancellationToken cancellationToken)
    {
        var allMajors = await _repository.GetAllAsync();
        return _mapper.Map<List<GetMajorDto>>(allMajors);
    }
}
