using FluentValidation;

namespace University.Application.Features.StudentCourses.Commands.DeleteStudentCourse;

internal class DeleteStudentCourseCommandValidator : AbstractValidator<DeleteStudentCourseCommand>
{
    public DeleteStudentCourseCommandValidator()
    {
        RuleFor(sc => sc.StudentCourseId).GreaterThan(0);
    }
}
