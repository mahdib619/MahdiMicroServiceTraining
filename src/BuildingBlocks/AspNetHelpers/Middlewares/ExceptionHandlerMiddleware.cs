using System.Net.Mime;
using System.Text.Json;
using GeneralHelpers.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using WebApplicationHelpers.Models;

namespace WebApplicationHelpers.Middlewares;

internal class ExceptionHandlerMiddleware
{
    private readonly bool _isDevMode;
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next, IHostEnvironment environment)
    {
        _isDevMode = environment.IsDevelopment();
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleException(httpContext, ex);
        }
    }

    private async Task HandleException(HttpContext context, Exception exception)
    {
        var problem = exception switch
        {
            NotFoundException nf => new { Title = "Error 404 Notfound!", Detail = nf.Message, Code = StatusCodes.Status404NotFound },
            EntityValidationException ev => new { Title = ev.Message, Detail = JsonSerializer.Serialize(ev.Errors), Code = StatusCodes.Status400BadRequest },
            ClientException ce => new { Title = "Error 400 BadRequest!", Detail = ce.Message, Code = StatusCodes.Status400BadRequest },
            _ when _isDevMode => new { Title = exception.Message, Detail = exception.StackTrace, Code = StatusCodes.Status500InternalServerError },
            _ => new { Title = "Internal Server Error!", Detail = string.Empty, Code = StatusCodes.Status500InternalServerError }
        };

        context.Response.StatusCode = problem.Code;
        context.Response.ContentType = MediaTypeNames.Application.Json;

        await context.Response.WriteAsync(new ErrorDetails
        {
            Detail = problem.Detail,
            StatusCode = context.Response.StatusCode,
            Title = problem.Title,
            Type = _isDevMode ? exception.GetType().ToString() : string.Empty
        }.ToString());
    }
}