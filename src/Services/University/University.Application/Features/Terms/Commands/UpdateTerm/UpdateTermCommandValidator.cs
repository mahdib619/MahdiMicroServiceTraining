using FluentValidation;

namespace University.Application.Features.Terms.Commands.UpdateTerm;

internal class UpdateTermCommandValidator : AbstractValidator<UpdateTermCommand>
{
    public UpdateTermCommandValidator()
    {
        RuleFor(ut => ut.Id).GreaterThan(0);

        RuleFor(ut => ut.Name).NotEmpty()
                              .MaximumLength(200);

        RuleFor(ut => ut.EndDate).GreaterThan(t => t.StartDate).WithMessage("{PropertyName} must be greater than {ComparisonProperty}.");
    }
}
