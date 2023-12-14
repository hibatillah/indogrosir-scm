using indogrosir_tim8.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace indogrosir_tim8.Controllers
{
    public class AuthController : Controller
    {
        private readonly indogrosir_tim8Context _context;

        public AuthController(indogrosir_tim8Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string email, string pass)
        {
            if (_context.Mitra == null)
            {
                return Problem("Entity set 'Mitra' is null.");
            }

            var emailMitra = await _context.Mitra
                .FirstOrDefaultAsync(m => m.Email == email);

            if (emailMitra == null)
            {
                return NotFound();
            } 
            else
            {
                var passMitra = emailMitra.Password;
                if (passMitra == pass)
                {
                    HttpContext.Session.SetString("email", emailMitra.ToString());
                    return RedirectToAction("Index", "SCM");
                }
            }
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
    }
}
