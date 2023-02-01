using FluentValidation;

namespace University.Application.Features.Students.Queries.GetStudentById;

internal class GetStudentByIdQueryValidator : AbstractValidator<GetStudentByIdQuery>
{
    public GetStudentByIdQueryValidator()
    {
        RuleFor(s => s.StudentId).GreaterThan(0);
    }
}
