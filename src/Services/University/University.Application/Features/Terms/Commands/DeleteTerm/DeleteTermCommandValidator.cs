using FluentValidation;

namespace University.Application.Features.Terms.Commands.DeleteTerm;

internal class DeleteTermCommandValidator : AbstractValidator<DeleteTermCommand>
{
    public DeleteTermCommandValidator()
    {
        RuleFor(dt => dt.TermId).GreaterThan(0);
    }
}
