using FluentValidation;

namespace University.Application.Features.Students.Commands.DeleteStudent;

internal class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentCommandValidator()
    {
        RuleFor(s => s.StudentId).GreaterThan(0);
    }
}
