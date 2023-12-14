using indogrosir_tim8.Data;
using indogrosir_tim8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace indogrosir_tim8.Controllers
{
    public class SCMController : Controller
    {
        private readonly indogrosir_tim8Context _context;

        public SCMController(indogrosir_tim8Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string email, string pass)
        {
            if (_context.Mitra == null)
            {
                return Problem("Entity set 'Mitra' is null.");
            }

            var mitra = await _context.Mitra
                .FirstOrDefaultAsync(m => m.Email == email);

            if (mitra.Email == email)
            {
                if (mitra.Password == pass)
                {
                    //HttpContext.Session.SetString("email", mitra.Email.ToString());
                    return View();
                }
            }
            return RedirectToAction("Index", "Auth");
        }

        public IActionResult Profil()
        {
            return View();
        }
    }
}
