using FluentValidation;

namespace University.Application.Features.Courses.Queries.GetCourseById;

internal class GetCourseByIdQueryValidator : AbstractValidator<GetCourseByIdQuery>
{
    public GetCourseByIdQueryValidator()
    {
        RuleFor(gc => gc.CourseId).GreaterThan(0);
    }
}
