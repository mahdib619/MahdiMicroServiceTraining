using FluentValidation;

namespace Financial.Application.Features.MajorFees.Queries.GetMajorFeeByMajorCode;

internal class GetMajorFeeByMajorCodeQueryValidator : AbstractValidator<GetMajorFeeByMajorCodeQuery>
{
    public GetMajorFeeByMajorCodeQueryValidator()
    {
        RuleFor(e => e.MajorCode).NotEmpty()
                                 .Length(7);
    }
}
