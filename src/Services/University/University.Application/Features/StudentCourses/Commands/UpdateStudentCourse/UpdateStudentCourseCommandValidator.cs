using FluentValidation;

namespace University.Application.Features.StudentCourses.Commands.UpdateStudentCourse;

internal class UpdateStudentCourseCommandValidator : AbstractValidator<UpdateStudentCourseCommand>
{
    public UpdateStudentCourseCommandValidator()
    {
        RuleFor(sc => sc.Id).GreaterThan(0);

        RuleFor(sc => sc).Must(sc => !(sc.IsDeleted && sc.IsPassed)).WithMessage("A Taken Course cannot be deleted and passed.");
    }
}
