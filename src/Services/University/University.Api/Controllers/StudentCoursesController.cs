using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.Dtos.StudentCourse;
using University.Application.Features.StudentCourses.Commands.CreateStudentCourse;
using University.Application.Features.StudentCourses.Commands.DeleteStudentCourse;
using University.Application.Features.StudentCourses.Commands.UpdateStudentCourse;
using University.Application.Features.StudentCourses.Queries.GetStudentCourseById;
using University.Application.Features.StudentCourses.Queries.GetStudentCoursesList;

namespace University.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class StudentCoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentCoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}", Name = nameof(GetStudentCourse))]
    public async Task<ActionResult<GetStudentCourseDto>> GetStudentCourse(int id)
    {
        var request = new GetStudentCourseByIdQuery { StudentCourseId = id };
        var studentCourse = await _mediator.Send(request);
        return Ok(studentCourse);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetStudentCourseDto>>> GetAllStudentCourses()
    {
        var request = new GetStudentCoursesListQuery();
        var studentCourse = await _mediator.Send(request);
        return Ok(studentCourse);
    }

    [HttpPost]
    public async Task<ActionResult<GetStudentCourseDto>> CreateStudentCourse(CreateStudentCourseCommand request)
    {
        var newStudentCourse = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetStudentCourse), new { newStudentCourse.Id }, newStudentCourse);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateStudentCourse(int id, UpdateStudentCourseCommand request)
    {
        request.Id = id;
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteStudentCourse(int id)
    {
        var request = new DeleteStudentCourseCommand { StudentCourseId = id };
        await _mediator.Send(request);
        return NoContent();
    }
}
