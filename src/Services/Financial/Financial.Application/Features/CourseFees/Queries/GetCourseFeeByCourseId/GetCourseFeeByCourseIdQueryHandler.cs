using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.CourseFee;
using Financial.Domain.Entities;
using GeneralHelpers.Exceptions;
using MediatR;

namespace Financial.Application.Features.CourseFees.Queries.GetCourseFeeByCourseId;

internal class GetCourseFeeByCourseIdQueryHandler : IRequestHandler<GetCourseFeeByCourseIdQuery, GetCourseFeeDto>
{
    private readonly ICourseFeesRepository _repository;
    private readonly IMapper _mapper;

    public GetCourseFeeByCourseIdQueryHandler(ICourseFeesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCourseFeeDto> Handle(GetCourseFeeByCourseIdQuery request, CancellationToken cancellationToken)
    {
        var courseFee = (await _repository.GetAsync(e => e.CourseId == request.CourseId)).SingleOrDefault();
        
        if (courseFee is null)
            throw new NotFoundException(nameof(CourseFee), request.CourseId);

        return _mapper.Map<GetCourseFeeDto>(courseFee);
    }
}
