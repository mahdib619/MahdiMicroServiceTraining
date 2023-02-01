using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Student;
using University.Application.Exceptions;
using University.Domain.Entities;

namespace University.Application.Features.Students.Queries.GetStudentById;

internal class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentDto>
{
    private readonly IStudentsRepository _repository;
    private readonly IMapper _mapper;

    public GetStudentByIdQueryHandler(IStudentsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetStudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var studentDb = await _repository.GetByIdAsync(request.StudentId);

        if (studentDb is null)
            throw new NotFoundException(nameof(Student), request.StudentId);

        var studentDto = _mapper.Map<GetStudentDto>(studentDb);

        return studentDto;
    }
}
