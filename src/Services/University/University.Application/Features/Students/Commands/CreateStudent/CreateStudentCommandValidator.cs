using FluentValidation;

namespace University.Application.Features.Students.Commands.CreateStudent;

internal class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(s => s.SignUpTermId).GreaterThan(0);

        RuleFor(s => s.MajorId).GreaterThan(0);

        RuleFor(s => s.StudentNumber).NotEmpty()
                                     .Length(15);

        RuleFor(s => s.FirstName).NotEmpty()
                                 .MaximumLength(100);

        RuleFor(s => s.LastName).NotEmpty()
                                .MaximumLength(200);
    }
}
