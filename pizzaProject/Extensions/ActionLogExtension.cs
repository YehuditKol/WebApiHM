using middlewares.Middleware;
namespace middlewares.Extensions;
public static class ActionLogbMiddlewareExtension
{
    public static IApplicationBuilder UseActionLog(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ActionLogbMiddleware>();
    }
}