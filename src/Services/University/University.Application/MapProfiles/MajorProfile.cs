using AutoMapper;
using University.Application.Dtos.Major;
using University.Application.Features.Majors.Commands.CreateMajor;
using University.Application.Features.Majors.Commands.UpdateMajor;
using University.Domain.Entities;

namespace University.Application.MapProfiles;

internal class MajorProfile : Profile
{
    public MajorProfile()
    {
        CreateMap<Major, GetMajorDto>();
        CreateMap<CreateMajorCommand, Major>();
        CreateMap<UpdateMajorCommand, Major>();
    }
}
