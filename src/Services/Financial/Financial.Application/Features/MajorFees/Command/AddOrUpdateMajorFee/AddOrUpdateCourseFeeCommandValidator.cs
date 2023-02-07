using FluentValidation;

namespace Financial.Application.Features.MajorFees.Command.AddOrUpdateMajorFee;

internal class AddOrUpdateMajorFeeCommandValidator : AbstractValidator<AddOrUpdateMajorFeeCommand>
{
    public AddOrUpdateMajorFeeCommandValidator()
    {
        RuleFor(e => e.MajorCode).NotEmpty()
                                 .Length(7);

        RuleFor(e => e.Fee).GreaterThan(0);
    }
}
