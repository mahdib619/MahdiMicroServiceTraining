using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Exception;
using University.Domain.Entities;

namespace University.Application.Features.Terms.Commands.UpdateTerm;

internal class UpdateTermCommandHandler : IRequestHandler<UpdateTermCommand>
{
    private readonly ITermsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateTermCommandHandler> _logger;

    public UpdateTermCommandHandler(ITermsRepository repository, IMapper mapper, ILogger<UpdateTermCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateTermCommand request, CancellationToken cancellationToken)
    {
        var term = _mapper.Map<Term>(request);

        var updated = await _repository.UpdateAsync(term);

        if (!updated)
            throw new NotFoundException(nameof(Term), request.Id);

        _logger.LogInformation("Term {TermId} is updated successfully.", request.Id);

        return Unit.Value;
    }
}
