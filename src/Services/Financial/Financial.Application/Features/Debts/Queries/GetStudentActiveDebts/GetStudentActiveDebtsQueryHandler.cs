using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.Debt;
using MediatR;

namespace Financial.Application.Features.Debts.Queries.GetStudentActiveDebts;

internal class GetStudentActiveDebtsQueryHandler : IRequestHandler<GetStudentActiveDebtsQuery, List<GetDebtDto>>
{
    private readonly IDebtsRepository _repository;
    private readonly IMapper _mapper;

    public GetStudentActiveDebtsQueryHandler(IDebtsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetDebtDto>> Handle(GetStudentActiveDebtsQuery request, CancellationToken cancellationToken)
    {
        var debts = await _repository.GetAsync(e => !e.IsDeleted && e.StudentNumber == request.StudentNumber && e.DateTime >= request.StartDate && e.DateTime <= request.EndDate);
        return _mapper.Map<List<GetDebtDto>>(debts);
    }
}
