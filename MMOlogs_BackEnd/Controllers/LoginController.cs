using Microsoft.AspNetCore.Mvc;

namespace MMOlogs_BackEnd.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
