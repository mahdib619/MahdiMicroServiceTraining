using Financial.Application.Dtos.Payment;
using Financial.Application.Features.Payments.Commands.CreatePayment;
using Financial.Application.Features.Payments.Queries.GetStudentSuccessfulPayments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetPaymentDto>>> GetStudentPayments([FromQuery] string studentNumber)
    {
        var request = new GetStudentSuccessFulPaymentsQuery(studentNumber);
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetPaymentDto>> CreatePayment(CreatePaymentCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
