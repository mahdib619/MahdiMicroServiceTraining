using Financial.Application.Dtos.MajorFee;
using Financial.Application.Features.MajorFees.Command.AddOrUpdateMajorFee;
using Financial.Application.Features.MajorFees.Queries.GetMajorFeeByMajorCode;
using Financial.Application.Features.MajorFees.Queries.GetMajorFeesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MajorFeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MajorFeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetMajorFeeDto>>> GetAllMajorFees()
    {
        var majorFees = await _mediator.Send(new GetMajorFeesListQuery());
        return Ok(majorFees);
    }

    [HttpGet("{majorCode}", Name = nameof(GetMajorFee))]
    public async Task<ActionResult<GetMajorFeeDto>> GetMajorFee(string majorCode)
    {
        var request = new GetMajorFeeByMajorCodeQuery { MajorCode = majorCode };
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetMajorFeeDto>> AddOrUpdateMajorFee(AddOrUpdateMajorFeeCommand request)
    {
        var result = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetMajorFee), new { result.MajorCode }, result);
    }
}
