using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Term;
using University.Application.Exceptions;
using University.Domain.Entities;

namespace University.Application.Features.Terms.Queries.GetTermById;

internal class GetTermByIdQueryHandler : IRequestHandler<GetTermByIdQuery, GetTermDto>
{
    private readonly ITermsRepository _repository;
    private readonly IMapper _mapper;

    public GetTermByIdQueryHandler(ITermsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetTermDto> Handle(GetTermByIdQuery request, CancellationToken cancellationToken)
    {
        var term = await _repository.GetByIdAsync(request.TermId);

        if (term is null)
            throw new NotFoundException(nameof(Term), request.TermId);

        return _mapper.Map<GetTermDto>(term);
    }
}
