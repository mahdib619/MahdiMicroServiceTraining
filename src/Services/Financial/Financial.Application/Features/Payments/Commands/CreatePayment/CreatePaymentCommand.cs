using Financial.Application.Dtos.Payment;
using MediatR;

namespace Financial.Application.Features.Payments.Commands.CreatePayment;

public class CreatePaymentCommand : IRequest<GetPaymentDto>
{
    public string StudentNumber { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentTime { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Description { get; set; }
}
