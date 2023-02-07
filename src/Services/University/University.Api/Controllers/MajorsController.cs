using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.Dtos.Major;
using University.Application.Features.Majors.Commands.CreateMajor;
using University.Application.Features.Majors.Commands.DeleteMajor;
using University.Application.Features.Majors.Commands.UpdateMajor;
using University.Application.Features.Majors.Queries.GetMajorById;
using University.Application.Features.Majors.Queries.GetMajorsList;

namespace University.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MajorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MajorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}", Name = nameof(GetMajor))]
    public async Task<ActionResult<GetMajorDto>> GetMajor(int id)
    {
        var request = new GetMajorByIdQuery { MajorId = id };
        var major = await _mediator.Send(request);
        return Ok(major);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetMajorDto>>> GetAllMajors()
    {
        var request = new GetMajorsListQuery();
        var Major = await _mediator.Send(request);
        return Ok(Major);
    }

    [HttpPost]
    public async Task<ActionResult<GetMajorDto>> CreateMajor(CreateMajorCommand request)
    {
        var newMajor = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetMajor), new { newMajor.Id }, newMajor);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateMajor(int id, UpdateMajorCommand request)
    {
        request.Id = id;
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMajor(int id)
    {
        var request = new DeleteMajorCommand { MajorId = id };
        await _mediator.Send(request);
        return NoContent();
    }
}
