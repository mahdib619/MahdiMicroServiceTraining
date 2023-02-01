using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using University.Application.Exceptions;

namespace University.Api.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("error")]
    public IActionResult ErrorHandler([FromServices] IWebHostEnvironment webHostEnvironment)
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;

        if (exception is null)
            throw new UnreachableException("Exception should never be null in error handler!");

        var isDevMode = webHostEnvironment.IsDevelopment();
        var problem = exception switch
        {
            NotFoundException nf => new { Title = "Error 404 Notfound!", Detail = nf.Message, Code = StatusCodes.Status404NotFound },
            EntityValidationException ev => new { Title = ev.Message, Detail = JsonSerializer.Serialize(ev.Errors), Code = StatusCodes.Status400BadRequest },
            _ when isDevMode => new { Title = exception.Message, Detail = exception.StackTrace, Code = StatusCodes.Status500InternalServerError },
            _ => new { Title = "Internal Server Error!", Detail = string.Empty, Code = StatusCodes.Status500InternalServerError }
        };
        Response.StatusCode = problem.Code;

        return Problem(detail: problem.Detail,
            statusCode: problem.Code,
            title: problem.Title,
            type: isDevMode ? exception.GetType().ToString() : string.Empty);
    }
}
