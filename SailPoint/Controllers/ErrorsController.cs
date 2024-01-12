using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SailPoint.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        [Route("/error")]
        public IActionResult Index()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            //return Problem(statusCode: 500, title: exception?.Message);
            return Problem(title: exception?.Message);

        }
    }
}
