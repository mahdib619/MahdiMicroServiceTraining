using AutoMapper;
using GeneralHelpers.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;

namespace University.Application.Features.Majors.Commands.UpdateMajor;

internal class UpdateMajorCommandHandler : IRequestHandler<UpdateMajorCommand>
{
    private readonly IMajorsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateMajorCommandHandler> _logger;

    public UpdateMajorCommandHandler(IMajorsRepository repository, IMapper mapper, ILogger<UpdateMajorCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateMajorCommand request, CancellationToken cancellationToken)
    {
        var major = await _repository.GetByIdAsync(request.Id);

        if (major is null)
            throw new NotFoundException(nameof(major), request.Id);

        _mapper.Map(request, major);

        await _repository.UpdateAsync(major);

        _logger.LogInformation("Major {MajorId} is updated successfully.", request.Id);

        return Unit.Value;
    }
}
