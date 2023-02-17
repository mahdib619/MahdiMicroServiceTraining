using FluentValidation;

namespace Financial.Application.Features.Debts.Commands.CreateCourseDebt;

internal class CreateCourseDebtCommandValidator : AbstractValidator<CreateCourseDebtCommand>
{
    public CreateCourseDebtCommandValidator()
    {
        RuleFor(e => e.CourseCode).NotEmpty()
                                  .Length(10);

        RuleFor(s => s.StudentNumber).NotEmpty()
                                     .Length(15);
    }
}
