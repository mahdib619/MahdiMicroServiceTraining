using AutoMapper;
using Financial.Application.Features.Balance.GetStudentTotalBalance;
using Grpc.Core;
using MediatR;

namespace Financial.Grpc.GrpcServices;

internal class GrpcBalanceService : GrpcBalance.GrpcBalanceBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GrpcBalanceService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public override async Task<GetStudentBalanceInfoRes> GetStudentBalanceInfo(GetStudentBalanceInfoReq request, ServerCallContext context)
    {
        var result = await _mediator.Send(_mapper.Map<GetStudentTotalBalanceQuery>(request));
        return new()
        {
            StudentNumber = result.StudentNumber,
            IsDebtor = result.TotalBalance < 0
        };
    }
}
