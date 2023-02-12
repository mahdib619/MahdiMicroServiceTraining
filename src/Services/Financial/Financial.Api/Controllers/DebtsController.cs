using Financial.Application.Dtos.Debt;
using Financial.Application.Features.Debts.Queries.GetStudentActiveDebts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DebtsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DebtsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<ActionResult<List<GetDebtDto>>> GetStudentDebts([FromQuery] string studentNumber)
    {
        var request = new GetStudentActiveDebtsQuery(studentNumber);
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
