using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Application.Dtos.Student;
using University.Application.Features.Students.Commands.CreateStudent;
using University.Application.Features.Students.Commands.DeleteStudent;
using University.Application.Features.Students.Commands.UpdateStudent;
using University.Application.Features.Students.Queries.GetStudentById;
using University.Application.Features.Students.Queries.GetStudentsList;

namespace University.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}", Name = nameof(GetStudent))]
    public async Task<ActionResult<GetStudentDto>> GetStudent(int id)
    {
        var request = new GetStudentByIdQuery { StudentId = id };
        var student = await _mediator.Send(request);
        return Ok(student);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetStudentDto>>> GetAllStudents()
    {
        var request = new GetStudentsListQuery();
        var student = await _mediator.Send(request);
        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<GetStudentDto>> CreateStudent(CreateStudentCommand request)
    {
        var newStudent = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetStudent), new { newStudent.Id }, newStudent);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateStudent(int id, UpdateStudentCommand request)
    {
        request.Id = id;
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteStudent(int id)
    {
        var request = new DeleteStudentCommand { StudentId = id };
        await _mediator.Send(request);
        return NoContent();
    }
}
