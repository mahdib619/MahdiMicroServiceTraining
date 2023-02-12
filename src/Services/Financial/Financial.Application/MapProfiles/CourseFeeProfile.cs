using AutoMapper;
using Financial.Application.Dtos.CourseFee;
using Financial.Application.Features.CourseFees.Command.AddOrUpdateCourseFee;
using Financial.Domain.Entities;

namespace Financial.Application.MapProfiles;

internal class CourseFeeProfile : Profile
{
    public CourseFeeProfile()
    {
        CreateMap<CourseFee, GetCourseFeeDto>();
        CreateMap<AddOrUpdateCourseFeeCommand, CourseFee>();
    }
}
