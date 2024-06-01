using WebAPI.Middlewares;

namespace WebAPI.Extensions;

public static class ApplicationBuilderExtensionMethods
{
    public static IApplicationBuilder UseGlobalExceptionHandler(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}