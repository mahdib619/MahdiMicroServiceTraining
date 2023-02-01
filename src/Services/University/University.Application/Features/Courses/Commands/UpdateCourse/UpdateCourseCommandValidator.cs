using FluentValidation;

namespace University.Application.Features.Courses.Commands.UpdateCourse;

internal class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
    {
        RuleFor(ut => ut.Id).GreaterThan(0);

        RuleFor(ut => ut.Name).NotEmpty()
                              .MaximumLength(200);

        RuleFor(ut => ut).Must(units => units.PracticalUnitsCount > 0 || units.TheoricalUnitsCount > 0)
                         .WithMessage("Course must have at least 1 unit.");
    }
}
