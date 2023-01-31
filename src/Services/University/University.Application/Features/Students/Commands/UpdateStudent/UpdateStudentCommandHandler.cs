using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Exception;
using University.Domain.Entities;

namespace University.Application.Features.Students.Commands.UpdateStudent;

internal class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly IStudentsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateStudentCommandHandler> _logger;

    public UpdateStudentCommandHandler(IStudentsRepository repository, IMapper mapper, ILogger<UpdateStudentCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var studentDb = await _repository.GetByIdAsync(request.Id);

        if (studentDb is null)
            throw new NotFoundException(nameof(Student), request.Id);

        _mapper.Map(request, studentDb);
        await _repository.UpdateAsync(studentDb);

        _logger.LogInformation("Student {StudentId} is updated successfully.", request.Id);

        return Unit.Value;
    }
}
