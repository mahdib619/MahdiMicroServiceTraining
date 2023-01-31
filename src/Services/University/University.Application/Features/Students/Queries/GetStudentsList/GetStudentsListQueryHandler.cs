using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Student;

namespace University.Application.Features.Students.Queries.GetStudentsList;

internal class GetStudentsListQueryHandler : IRequestHandler<GetStudentsListQuery, List<GetStudentDto>>
{
    private readonly IStudentsRepository _repository;
    private readonly IMapper _mapper;

    public GetStudentsListQueryHandler(IStudentsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetStudentDto>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
    {
        var studentsDb = await _repository.GetAllAsync();
        var studentsDto = _mapper.Map<List<GetStudentDto>>(studentsDb);
        return studentsDto;
    }
}
