using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.Dtos.Course;
using University.Application.Features.Courses.Commands.CreateCourse;
using University.Application.Features.Courses.Commands.DeleteCourse;
using University.Application.Features.Courses.Commands.UpdateCourse;
using University.Application.Features.Courses.Queries.GetCourseById;
using University.Application.Features.Courses.Queries.GetCoursesList;

namespace University.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}", Name = nameof(GetCourse))]
    public async Task<ActionResult<GetCourseDto>> GetCourse(int id)
    {
        var request = new GetCourseByIdQuery { CourseId = id };
        var course = await _mediator.Send(request);
        return Ok(course);
    }

    [HttpGet]
    public async Task<ActionResult<GetCourseDto>> GetAllCourses()
    {
        var request = new GetCoursesListQuery();
        var course = await _mediator.Send(request);
        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<GetCourseDto>> CreateCourse(CreateCourseCommand request)
    {
        var newCourse = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetCourse), new { newCourse.Id }, newCourse);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<GetCourseDto>> UpdateCourse(int id, UpdateCourseCommand request)
    {
        request.Id = id;
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<GetCourseDto>> DeleteCourse(int id)
    {
        var request = new DeleteCourseCommand { CourseId = id };
        await _mediator.Send(request);
        return NoContent();
    }
}
