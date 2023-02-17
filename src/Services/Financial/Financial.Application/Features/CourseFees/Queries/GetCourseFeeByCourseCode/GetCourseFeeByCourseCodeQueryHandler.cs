using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.CourseFee;
using Financial.Domain.Entities;
using GeneralHelpers.Exceptions;
using MediatR;

namespace Financial.Application.Features.CourseFees.Queries.GetCourseFeeByCourseCode;

internal class GetCourseFeeByCourseCodeQueryHandler : IRequestHandler<GetCourseFeeByCourseCodeQuery, GetCourseFeeDto>
{
    private readonly ICourseFeesRepository _repository;
    private readonly IMapper _mapper;

    public GetCourseFeeByCourseCodeQueryHandler(ICourseFeesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCourseFeeDto> Handle(GetCourseFeeByCourseCodeQuery request, CancellationToken cancellationToken)
    {
        var courseFee = (await _repository.GetAsync(e => e.CourseCode == request.CourseCode)).SingleOrDefault();
        
        if (courseFee is null)
            throw new NotFoundException(nameof(CourseFee), request.CourseCode);

        return _mapper.Map<GetCourseFeeDto>(courseFee);
    }
}
