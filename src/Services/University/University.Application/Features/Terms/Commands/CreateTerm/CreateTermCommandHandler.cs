using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Course;
using University.Application.Dtos.Term;
using University.Domain.Entities;

namespace University.Application.Features.Terms.Commands.CreateTerm;

internal class CreateTermCommandHandler : IRequestHandler<CreateTermCommand, GetTermDto>
{
    private readonly ITermsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateTermCommandHandler> _logger;

    public CreateTermCommandHandler(ITermsRepository repository, IMapper mapper, ILogger<CreateTermCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetTermDto> Handle(CreateTermCommand request, CancellationToken cancellationToken)
    {
        var term = _mapper.Map<Term>(request);
        var addedTerm = await _repository.AddAsync(term);

        var termRes = _mapper.Map<GetTermDto>(addedTerm);

        _logger.LogInformation("New Term:{@Term} is added successfully.", termRes);

        return termRes;
    }
}
