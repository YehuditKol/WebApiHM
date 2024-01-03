using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzaProject.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
       
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next delegate/middleware in the pipeline.
                await _next(context);
               
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ErrorsController : ControllerBase
    //{
    //    ILogger<ErrorsController> logger;
    //public ErrorsController(ILogger<ErrorsController> logger)
    //{
    //    this.logger = logger;
    //}

    //[Route("/error")]
    //public ActionResult Error([FromServices] IHostEnvironment hostEnvironment)
    //{
    //    var exceptionHandlerFeature =
    //        HttpContext.Features.Get<IExceptionHandlerFeature>();
    //    logger.LogError(exceptionHandlerFeature?.Error.ToString());

    //    return Problem(
    //        detail: "Please try later...",
    //        title: "Sorry...");

    //}
    //[Route("/error-development")]
    //public ActionResult DevelopmentError([FromServices] IHostEnvironment hostEnvironment)
    //    {
    //        if (hostEnvironment.IsDevelopment)
    //        {
    //            IExceptionHandlerFeature? exceptionHandlerFeature =
    //                HttpContext.Features.Get<IExceptionHandlerFeature>();
    //            logger.LogError(exceptionHandlerFeature?.Error.ToString());

    //            return Problem(
    //                detail: exceptionHandlerFeature.Error.StackTrace,
    //                title: exceptionHandlerFeature.Error.Message);
    //        }
    //        return Error(hostEnvironment);

    //    }

    //}
}
