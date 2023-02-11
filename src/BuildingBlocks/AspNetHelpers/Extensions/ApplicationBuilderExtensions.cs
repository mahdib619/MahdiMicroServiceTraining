using AspNetHelpers.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AspNetHelpers.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseCommonExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}