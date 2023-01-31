using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Student;
using University.Domain.Entities;

namespace University.Application.Features.Students.Commands.CreateStudent;

internal class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, GetStudentDto>
{
    private readonly IStudentsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateStudentCommandHandler> _logger;

    public CreateStudentCommandHandler(IStudentsRepository repository, IMapper mapper, ILogger<CreateStudentCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetStudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var studentReq = _mapper.Map<Student>(request);
        var student = await _repository.AddAsync(studentReq);

        var studentDto = _mapper.Map<GetStudentDto>(student);

        _logger.LogInformation("New Student:{@Student} is added successfully.", studentDto);

        return studentDto;
    }
}
