using FluentValidation;

namespace Financial.Application.Features.Debts.Commands.CreateMajorDebt;

internal class CreateMajorDebtCommandValidator : AbstractValidator<CreateMajorDebtCommand>
{
    public CreateMajorDebtCommandValidator()
    {
        RuleFor(e => e.MajorCode).NotEmpty()
                                 .Length(7);

        RuleFor(s => s.StudentNumber).NotEmpty()
                                     .Length(15);
    }
}
