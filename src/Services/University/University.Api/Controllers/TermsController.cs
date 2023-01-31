using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.Dtos.Term;
using University.Application.Features.Terms.Commands.CreateTerm;
using University.Application.Features.Terms.Commands.DeleteTerm;
using University.Application.Features.Terms.Commands.UpdateTerm;
using University.Application.Features.Terms.Queries.GetTermById;
using University.Application.Features.Terms.Queries.GetTermsList;

namespace University.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TermsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TermsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}", Name = nameof(GetTerm))]
    public async Task<ActionResult<GetTermDto>> GetTerm(int id)
    {
        var request = new GetTermByIdQuery { TermId = id };
        var term = await _mediator.Send(request);
        return Ok(term);
    }

    [HttpGet]
    public async Task<ActionResult<GetTermDto>> GetAllTerms()
    {
        var request = new GetTermsListQuery();
        var term = await _mediator.Send(request);
        return Ok(term);
    }

    [HttpPost]
    public async Task<ActionResult<GetTermDto>> CreateTerm(CreateTermCommand request)
    {
        var newTerm = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetTerm), new { newTerm.Id }, newTerm);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<GetTermDto>> UpdateTerm(int id, UpdateTermCommand request)
    {
        request.Id = id;
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<GetTermDto>> DeleteTerm(int id)
    {
        var request = new DeleteTermCommand { TermId = id };
        await _mediator.Send(request);
        return NoContent();
    }
}
