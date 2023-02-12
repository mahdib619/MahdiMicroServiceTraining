using AutoMapper;
using Financial.Application.Features.Balance.GetStudentTotalBalance;

namespace Financial.Grpc.MapProfiles;

public class BalanceProfile : Profile
{
    public BalanceProfile()
    {
        CreateMap<GetStudentBalanceInfoReq, GetStudentTotalBalanceQuery>()
            .ForMember(d => d.StartDate, m => m.MapFrom(s => s.StartDate > 0 ? new DateTime(s.StartDate) : DateTime.MinValue))
            .ForMember(d => d.EndDate, m => m.MapFrom(s => s.EndDate > 0 ? new DateTime(s.EndDate) : DateTime.MaxValue));
    }
}
