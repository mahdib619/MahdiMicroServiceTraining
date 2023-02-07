using FluentValidation;

namespace University.Application.Features.Majors.Commands.DeleteMajor;

internal class DeleteMajorCommandValidator : AbstractValidator<DeleteMajorCommand>
{
    public DeleteMajorCommandValidator()
    {
        RuleFor(dc => dc.MajorId).GreaterThan(0);
    }
}
