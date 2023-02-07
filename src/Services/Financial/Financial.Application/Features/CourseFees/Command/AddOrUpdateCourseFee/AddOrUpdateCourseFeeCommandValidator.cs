using FluentValidation;

namespace Financial.Application.Features.CourseFees.Command.AddOrUpdateCourseFee;

internal class AddOrUpdateCourseFeeCommandValidator : AbstractValidator<AddOrUpdateCourseFeeCommand>
{
    public AddOrUpdateCourseFeeCommandValidator()
    {
        RuleFor(e => e.CourseId).GreaterThan(0);
        RuleFor(e => e.Fee).GreaterThan(0);
    }
}
