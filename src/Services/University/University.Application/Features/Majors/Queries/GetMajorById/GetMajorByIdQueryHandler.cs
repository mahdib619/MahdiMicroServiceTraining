using AutoMapper;
using MediatR;
using University.Application.Contracts.Persistence;
using University.Application.Dtos.Major;
using University.Application.Exceptions;
using University.Domain.Entities;

namespace University.Application.Features.Majors.Queries.GetMajorById;

internal class GetMajorByIdQueryHandler : IRequestHandler<GetMajorByIdQuery, GetMajorDto>
{
    private readonly IMajorsRepository _repository;
    private readonly IMapper _mapper;

    public GetMajorByIdQueryHandler(IMajorsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetMajorDto> Handle(GetMajorByIdQuery request, CancellationToken cancellationToken)
    {
        var Major = await _repository.GetByIdAsync(request.MajorId);

        if (Major is null)
            throw new NotFoundException(nameof(Major), request.MajorId);

        return _mapper.Map<GetMajorDto>(Major);
    }
}
