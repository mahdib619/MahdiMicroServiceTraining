using FluentValidation;

namespace University.Application.Features.StudentCourses.Commands.CreateStudentCourse;

internal class CreateStudentCourseCommandValidator : AbstractValidator<CreateStudentCourseCommand>
{
    public CreateStudentCourseCommandValidator()
    {
        RuleFor(sc => sc.StudentId).GreaterThan(0);
        RuleFor(sc => sc.CourseId).GreaterThan(0);
        RuleFor(sc => sc.TermId).GreaterThan(0);
    }
}
