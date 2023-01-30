using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Term;

namespace University.Application.Features.Terms.Queries.GetTermsList;

internal class GetTermsListQueryHandler : IRequestHandler<GetTermsListQuery, List<GetTermDto>>
{
    private readonly ITermsRepository _repository;
    private readonly IMapper _mapper;

    public GetTermsListQueryHandler(ITermsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetTermDto>> Handle(GetTermsListQuery request, CancellationToken cancellationToken)
    {
        var allTerms = await _repository.GetAllAsync();
        return _mapper.Map<List<GetTermDto>>(allTerms);
    }
}
