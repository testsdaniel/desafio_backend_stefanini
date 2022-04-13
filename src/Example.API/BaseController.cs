using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Example.API
{
    public abstract class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        [NonAction]
        public IActionResult ExceptionHandling(Exception ex)
            => StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
    }
}
