using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Major;
using University.Domain.Entities;

namespace University.Application.Features.Majors.Commands.CreateMajor;

internal class CreateMajorCommandHandler : IRequestHandler<CreateMajorCommand, GetMajorDto>
{
    private readonly IMajorsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateMajorCommandHandler> _logger;

    public CreateMajorCommandHandler(IMajorsRepository repository, IMapper mapper, ILogger<CreateMajorCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetMajorDto> Handle(CreateMajorCommand request, CancellationToken cancellationToken)
    {
        var major = _mapper.Map<Major>(request);
        var addedMajor = await _repository.AddAsync(major);

        var majorRes = _mapper.Map<GetMajorDto>(addedMajor);

        _logger.LogInformation("New Major:{@Major} is added successfully.", majorRes);

        return majorRes;
    }
}
