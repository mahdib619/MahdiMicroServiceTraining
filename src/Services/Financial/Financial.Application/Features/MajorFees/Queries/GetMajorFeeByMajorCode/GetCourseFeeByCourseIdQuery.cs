using Financial.Application.Dtos.MajorFee;
using MediatR;

namespace Financial.Application.Features.MajorFees.Queries.GetMajorFeeByMajorCode;

public class GetMajorFeeByMajorCodeQuery : IRequest<GetMajorFeeDto>
{
    public string MajorCode { get; set; }
}
