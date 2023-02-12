using AutoMapper;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using University.Application.Contracts.SyncDataServices;
using University.Application.Dtos.StudentBalance;

namespace University.Infrasturcture.SyncDataServices.Grpc;

internal class GrpcStudentBalanceDataClient : IStudentBalanceDataClient
{
    private readonly string _grpcUrl;
    private readonly IMapper _mapper;

    public GrpcStudentBalanceDataClient(IConfiguration configuration, IMapper mapper)
    {
        _grpcUrl = configuration["FinancialGrpcUrl"];
        _mapper = mapper;
    }

    public async Task<GetStudentBalanceInfoDto> GetStudentBalanceInfo(string studentNumber, DateTime? startDate = null, DateTime? endDate = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(studentNumber);

        var channel = GrpcChannel.ForAddress(_grpcUrl);
        var client = new GrpcBalance.GrpcBalanceClient(channel);

        var request = new GetStudentBalanceInfoReq
        {
            StudentNumber = studentNumber,
            StartDate = startDate?.Ticks ?? 0,
            EndDate = endDate?.Ticks ?? 0
        };
        var result = await client.GetStudentBalanceInfoAsync(request);
        
        return _mapper.Map<GetStudentBalanceInfoDto>(result);
    }
}
