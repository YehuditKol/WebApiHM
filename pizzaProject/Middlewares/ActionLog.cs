using System.Diagnostics;
using System.Globalization;
using ourProject.FileService;

namespace middlewares.Middleware;

public class ActionLogbMiddleware
{
    private readonly RequestDelegate _next;
    private ILog _logService;
    public ActionLogbMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,ILog logService)
    {
        _logService=logService;
        logService.WriteMessage(DateTime.Now);
        logService.WriteMessage(context.Request.Method);
        logService.WriteMessage(context.Request.Body);
        logService.WriteMessage(context.Request.Headers);

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
        logService.WriteMessage(DateTime.Now);
        logService.WriteMessage(context.Response.StatusCode);
        logService.WriteMessage(context.Response.Body);
        
    }
}
