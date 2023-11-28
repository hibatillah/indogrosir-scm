using Microsoft.AspNetCore.Mvc;

namespace indogrosir_tim8.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
    }
}
