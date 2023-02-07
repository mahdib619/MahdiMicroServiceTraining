using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.MajorFee;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Financial.Application.Features.MajorFees.Command.AddOrUpdateMajorFee;

internal class AddOrUpdateMajorFeeCommandHandler : IRequestHandler<AddOrUpdateMajorFeeCommand, GetMajorFeeDto>
{
    private readonly IMajorFeesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<AddOrUpdateMajorFeeCommandHandler> _logger;

    public AddOrUpdateMajorFeeCommandHandler(IMajorFeesRepository repository, IMapper mapper, ILogger<AddOrUpdateMajorFeeCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetMajorFeeDto> Handle(AddOrUpdateMajorFeeCommand request, CancellationToken cancellationToken)
    {
        var majorFee = (await _repository.GetAsync(e => e.MajorCode == request.MajorCode)).SingleOrDefault();

        if (majorFee is null)
        {
            majorFee = _mapper.Map<Domain.Entities.MajorFee>(request);
            await _repository.AddAsync(majorFee);
        }
        else
        {
            _mapper.Map(request, majorFee);
            await _repository.UpdateAsync(majorFee);
        }

        var response = _mapper.Map<GetMajorFeeDto>(majorFee);

        _logger.LogInformation("MajorFee:{@MajorFee} is updated successfully.", majorFee);
        
        return response;
    }
}
