using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.MajorFee;
using Financial.Domain.Entities;
using GeneralHelpers.Exceptions;
using MediatR;

namespace Financial.Application.Features.MajorFees.Queries.GetMajorFeeByMajorCode;

internal class GetMajorFeeByMajorCodeQueryHandler : IRequestHandler<GetMajorFeeByMajorCodeQuery, GetMajorFeeDto>
{
    private readonly IMajorFeesRepository _repository;
    private readonly IMapper _mapper;

    public GetMajorFeeByMajorCodeQueryHandler(IMajorFeesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetMajorFeeDto> Handle(GetMajorFeeByMajorCodeQuery request, CancellationToken cancellationToken)
    {
        var majorFee = (await _repository.GetAsync(e => e.MajorCode == request.MajorCode)).SingleOrDefault();
        
        if (majorFee is null)
            throw new NotFoundException(nameof(MajorFee), request.MajorCode);

        return _mapper.Map<GetMajorFeeDto>(majorFee);
    }
}
