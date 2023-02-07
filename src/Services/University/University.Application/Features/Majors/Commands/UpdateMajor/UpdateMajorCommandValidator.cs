using FluentValidation;

namespace University.Application.Features.Majors.Commands.UpdateMajor;

internal class UpdateMajorCommandValidator : AbstractValidator<UpdateMajorCommand>
{
    public UpdateMajorCommandValidator()
    {
        RuleFor(ut => ut.Id).GreaterThan(0);

        RuleFor(ut => ut.Name).NotEmpty()
                              .MaximumLength(200);
    }
}
