using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.MajorFee;
using MediatR;

namespace Financial.Application.Features.MajorFees.Queries.GetMajorFeesList;

internal class GetMajorFeesListQueryHandler : IRequestHandler<GetMajorFeesListQuery, List<GetMajorFeeDto>>
{
    private readonly IMajorFeesRepository _repository;
    private readonly IMapper _mapper;

    public GetMajorFeesListQueryHandler(IMajorFeesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetMajorFeeDto>> Handle(GetMajorFeesListQuery request, CancellationToken cancellationToken)
    {
        var all = await _repository.GetAllAsync();
        return _mapper.Map<List<GetMajorFeeDto>>(all);
    }
}
