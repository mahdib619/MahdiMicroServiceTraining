using FluentValidation;

namespace Financial.Application.Features.Debts.Queries.GetStudentActiveDebts;

internal class GetStudentActiveDebtsQueryValidator : AbstractValidator<GetStudentActiveDebtsQuery>
{
    public GetStudentActiveDebtsQueryValidator()
    {
        RuleFor(s => s.StudentNumber).NotEmpty()
                                     .Length(15);

        RuleFor(e => e).Must(e => e.EndDate > e.StartDate).WithMessage("EndDate must be after StartDate!");
    }
}
