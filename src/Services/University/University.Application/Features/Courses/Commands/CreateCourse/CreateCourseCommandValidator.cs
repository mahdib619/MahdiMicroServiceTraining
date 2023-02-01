using FluentValidation;

namespace University.Application.Features.Courses.Commands.CreateCourse;

internal class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(cc => cc.Name).NotEmpty()
                              .MaximumLength(200);

        RuleFor(cc => cc).Must(units => units.PracticalUnitsCount > 0 || units.TheoricalUnitsCount > 0)
                         .WithMessage("Course must have at least 1 unit.");
    }
}
