using AutoMapper;
using Financial.Application.Dtos.MajorFee;
using Financial.Application.Features.MajorFees.Command.AddOrUpdateMajorFee;
using Financial.Domain.Entities;

namespace Financial.Application.MapProfiles;

internal class MajorFeeProfile : Profile
{
    public MajorFeeProfile()
    {
        CreateMap<MajorFee, GetMajorFeeDto>();
        CreateMap<AddOrUpdateMajorFeeCommand, MajorFee>();
    }
}
