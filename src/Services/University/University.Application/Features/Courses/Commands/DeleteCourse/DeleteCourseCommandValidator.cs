using FluentValidation;

namespace University.Application.Features.Courses.Commands.DeleteCourse;

internal class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
{
    public DeleteCourseCommandValidator()
    {
        RuleFor(dc => dc.CourseId).GreaterThan(0);
    }
}
