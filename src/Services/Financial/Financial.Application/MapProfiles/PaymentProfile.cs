using AutoMapper;
using Financial.Application.Dtos.Payment;
using Financial.Application.Features.Payments.Commands.CreatePayment;
using Financial.Domain.Entities;

namespace Financial.Application.MapProfiles;

internal class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, GetPaymentDto>();
        CreateMap<CreatePaymentCommand, Payment>();
    }
}
