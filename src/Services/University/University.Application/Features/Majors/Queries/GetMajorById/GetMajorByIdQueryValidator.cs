using FluentValidation;

namespace University.Application.Features.Majors.Queries.GetMajorById;

internal class GetMajorByIdQueryValidator : AbstractValidator<GetMajorByIdQuery>
{
    public GetMajorByIdQueryValidator()
    {
        RuleFor(gc => gc.MajorId).GreaterThan(0);
    }
}
