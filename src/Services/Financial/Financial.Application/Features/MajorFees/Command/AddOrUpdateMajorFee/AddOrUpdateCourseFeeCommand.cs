using Financial.Application.Dtos.MajorFee;
using MediatR;

namespace Financial.Application.Features.MajorFees.Command.AddOrUpdateMajorFee;

public class AddOrUpdateMajorFeeCommand : IRequest<GetMajorFeeDto>
{
    public string MajorCode { get; set; }
    public decimal Fee { get; set; }
}
