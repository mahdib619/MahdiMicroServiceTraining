using FluentValidation;

namespace University.Application.Features.Terms.Commands.CreateTerm;

internal class CreateTermCommandValidator : AbstractValidator<CreateTermCommand>
{
    public CreateTermCommandValidator()
    {
        RuleFor(ct => ct.Name).NotEmpty()
                              .MaximumLength(200);

        RuleFor(ct => ct.EndDate).GreaterThan(t => t.StartDate).WithMessage("{PropertyName} must be greater than {ComparisonProperty}.");
    }
}
