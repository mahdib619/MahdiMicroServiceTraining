using Financial.Application.Dtos.CourseFee;
using Financial.Application.Features.CourseFees.Command.AddOrUpdateCourseFee;
using Financial.Application.Features.CourseFees.Queries.GetCourseFeeByCourseCode;
using Financial.Application.Features.CourseFees.Queries.GetCourseFeesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CourseFeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseFeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetCourseFeeDto>>> GetAllCourseFees()
    {
        var courseFees = await _mediator.Send(new GetCourseFeesListQuery());
        return Ok(courseFees);
    }

    [HttpGet("{courseCode}", Name = nameof(GetCourseFee))]
    public async Task<ActionResult<GetCourseFeeDto>> GetCourseFee(string courseCode)
    {
        var request = new GetCourseFeeByCourseCodeQuery { CourseCode = courseCode };
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetCourseFeeDto>> AddOrUpdateCourseFee(AddOrUpdateCourseFeeCommand request)
    {
        var result = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetCourseFee), new { result.CourseCode }, result);
    }
}
