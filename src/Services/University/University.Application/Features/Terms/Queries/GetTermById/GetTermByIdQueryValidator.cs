using FluentValidation;

namespace University.Application.Features.Terms.Queries.GetTermById;

internal class GetTermByIdQueryValidator : AbstractValidator<GetTermByIdQuery>
{
    public GetTermByIdQueryValidator()
    {
        RuleFor(gt => gt.TermId).GreaterThan(0);
    }
}
