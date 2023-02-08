using FluentValidation;

namespace Financial.Application.Features.Payments.Queries.GetStudentSuccessfulPayments;

internal class GetStudentSuccessFulPaymentsQueryValidator : AbstractValidator<GetStudentSuccessFulPaymentsQuery>
{
    public GetStudentSuccessFulPaymentsQueryValidator()
    {
        RuleFor(s => s.StudentNumber).NotEmpty()
                                     .Length(15);

        RuleFor(e => e).Must(e => e.EndDate > e.StartDate).WithMessage("EndDate must be after StartDate!");
    }
}
