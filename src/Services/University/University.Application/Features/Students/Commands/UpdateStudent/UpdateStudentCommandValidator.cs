using FluentValidation;

namespace University.Application.Features.Students.Commands.UpdateStudent;

internal class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(s => s.Id).GreaterThan(0);

        RuleFor(s => s.FirstName).NotEmpty()
                                 .MaximumLength(100);

        RuleFor(s => s.LastName).NotEmpty()
                                .MaximumLength(200);
    }
}
