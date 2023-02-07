using FluentValidation;

namespace Financial.Application.Features.CourseFees.Queries.GetCourseFeeByCourseId;

internal class GetCourseFeeByCourseIdQueryValidator : AbstractValidator<GetCourseFeeByCourseIdQuery>
{
    public GetCourseFeeByCourseIdQueryValidator()
    {
        RuleFor(e => e.CourseId).GreaterThan(0);
    }
}
