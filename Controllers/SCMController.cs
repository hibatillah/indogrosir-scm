using indogrosir_tim8.Data;
using indogrosir_tim8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Authorization;

namespace indogrosir_tim8.Controllers
{
    public class SCMController : Controller
    {
        private readonly indogrosir_tim8Context _context;
        private readonly IHttpContextAccessor _accessor;

        public SCMController(indogrosir_tim8Context context, IHttpContextAccessor accessor)
        {
            _context = context; 
            _accessor = accessor;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string pass)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMonths(1);

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
                    Response.Cookies.Append("user_id", mitra.Id.ToString(), options);
                    return View();
                }
                else
                {
                    return Problem("Password salah!");
                }
            }
            else
            {
                return Problem("Email tidak sesuai");
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteCookie()
        {
            // Delete the cookie from the browser.
            Response.Cookies.Delete("Name");

            return RedirectToAction("Index");
        }

        public IActionResult Profil()
        {
            return View();
        }
    }
}
