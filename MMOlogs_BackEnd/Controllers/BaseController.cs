using Microsoft.AspNetCore.Mvc;

namespace MMOlogs_BackEnd.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleSuccess(object data)
        {
            return Ok(new { data, success = true, code = 200 });
        }

        protected IActionResult HandleException(Exception ex)
        {
            return ex switch
            {
                ArgumentException or InvalidOperationException => Ok(new { success = false, message = ex.Message }),
                _ => NotFound(new { success = false, code = 404 })
            };
        }
    }
}
