using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PedidosAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError() => Problem();

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
            [FromServices] IHostEnvironment hostEnvirorment)
        {
            if (!hostEnvirorment.IsDevelopment())
            {
                return NotFound();
            }

            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: exception.Error.StackTrace,
                title: exception.Error.Message);

        }
    }
}
