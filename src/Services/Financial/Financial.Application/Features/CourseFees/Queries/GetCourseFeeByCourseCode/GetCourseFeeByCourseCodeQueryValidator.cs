using FluentValidation;

namespace Financial.Application.Features.CourseFees.Queries.GetCourseFeeByCourseCode;

internal class GetCourseFeeByCourseCodeQueryValidator : AbstractValidator<GetCourseFeeByCourseCodeQuery>
{
    public GetCourseFeeByCourseCodeQueryValidator()
    {
        RuleFor(e => e.CourseCode).NotEmpty()
                                  .Length(10);
    }
}
