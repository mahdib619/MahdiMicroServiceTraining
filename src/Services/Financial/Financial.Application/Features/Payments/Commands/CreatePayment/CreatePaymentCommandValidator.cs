using FluentValidation;

namespace Financial.Application.Features.Payments.Commands.CreatePayment;

internal class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(e => e.StudentNumber).NotEmpty()
                                     .Length(15);

        RuleFor(e => e.Amount).GreaterThan(0);
    }
}
