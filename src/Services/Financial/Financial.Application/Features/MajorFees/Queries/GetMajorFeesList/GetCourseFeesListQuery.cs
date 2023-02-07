using Financial.Application.Dtos.MajorFee;
using MediatR;

namespace Financial.Application.Features.MajorFees.Queries.GetMajorFeesList;

public class GetMajorFeesListQuery : IRequest<List<GetMajorFeeDto>>
{
}
