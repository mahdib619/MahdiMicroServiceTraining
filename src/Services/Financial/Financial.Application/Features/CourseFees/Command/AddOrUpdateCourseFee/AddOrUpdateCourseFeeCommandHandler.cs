using AutoMapper;
using Financial.Application.Contracts.Persistence;
using Financial.Application.Dtos.CourseFee;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Financial.Application.Features.CourseFees.Command.AddOrUpdateCourseFee;

internal class AddOrUpdateCourseFeeCommandHandler : IRequestHandler<AddOrUpdateCourseFeeCommand, GetCourseFeeDto>
{
    private readonly ICourseFeesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<AddOrUpdateCourseFeeCommandHandler> _logger;

    public AddOrUpdateCourseFeeCommandHandler(ICourseFeesRepository repository, IMapper mapper, ILogger<AddOrUpdateCourseFeeCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetCourseFeeDto> Handle(AddOrUpdateCourseFeeCommand request, CancellationToken cancellationToken)
    {
        var courseFee = (await _repository.GetAsync(e => e.CourseCode == request.CourseCode)).SingleOrDefault();

        if (courseFee is null)
        {
            courseFee = _mapper.Map<Domain.Entities.CourseFee>(request);
            await _repository.AddAsync(courseFee);
        }
        else
        {
            _mapper.Map(request, courseFee);
            await _repository.UpdateAsync(courseFee);
        }

        var response = _mapper.Map<GetCourseFeeDto>(courseFee);

        _logger.LogInformation("CourseFee:{@CourseFee} is updated successfully.", courseFee);

        return response;
    }
}
