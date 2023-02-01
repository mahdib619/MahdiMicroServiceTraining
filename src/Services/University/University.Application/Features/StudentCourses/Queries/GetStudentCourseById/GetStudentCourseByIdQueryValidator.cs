using FluentValidation;

namespace University.Application.Features.StudentCourses.Queries.GetStudentCourseById;

internal class GetStudentCourseByIdQueryValidator : AbstractValidator<GetStudentCourseByIdQuery>
{
    public GetStudentCourseByIdQueryValidator()
    {
        RuleFor(sc => sc.StudentCourseId).GreaterThan(0);
    }
}
