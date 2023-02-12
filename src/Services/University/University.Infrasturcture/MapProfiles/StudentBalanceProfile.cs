using AutoMapper;
using University.Application.Dtos.StudentBalance;
using University.Infrasturcture.SyncDataServices.Grpc;

namespace University.Infrasturcture.MapProfiles;

internal class StudentBalanceProfile : Profile
{
    public StudentBalanceProfile()
    {
        CreateMap<GetStudentBalanceInfoRes, GetStudentBalanceInfoDto>();
    }
}
