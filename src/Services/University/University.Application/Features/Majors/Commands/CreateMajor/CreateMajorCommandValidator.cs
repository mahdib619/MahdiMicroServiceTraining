using FluentValidation;

namespace University.Application.Features.Majors.Commands.CreateMajor;

internal class CreateMajorCommandValidator : AbstractValidator<CreateMajorCommand>
{
    public CreateMajorCommandValidator()
    {
        RuleFor(cc => cc.Name).NotEmpty()
                              .MaximumLength(200);
    }
}
