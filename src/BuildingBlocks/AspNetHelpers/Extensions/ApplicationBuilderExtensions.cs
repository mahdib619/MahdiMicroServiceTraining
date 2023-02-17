using Microsoft.AspNetCore.Builder;
using WebApplicationHelpers.Middlewares;

namespace WebApplicationHelpers.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseCommonExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}