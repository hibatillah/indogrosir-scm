using indogrosir_tim8.Data;
using indogrosir_tim8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace indogrosir_tim8.Controllers
{
    public class AuthController : Controller
    {
        private readonly indogrosir_tim8Context _context;
        private readonly IHttpContextAccessor _accessor;

        public AuthController(indogrosir_tim8Context context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string pass)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMonths(1);

            if (_context.Mitra == null)
            {
                return Problem("Entity set 'Mitra' is null.");
            }
            else if (_context.Admin == null)
            {
                return Problem("Entity set 'Admin' is null.");
            }

            var mitra = await _context.Mitra
                .FirstOrDefaultAsync(m => m.Email == email);

            var admin = await _context.Admin
                .FirstOrDefaultAsync(m => m.Email == email);

            if (mitra.Email == email)
            {
                if (mitra.Password == pass)
                {
                    Response.Cookies.Append("user_id", mitra.Id.ToString(), options);
                    Response.Cookies.Append("user_role", "mitra", options);
                    return RedirectToAction("Index", "SCM");
                }
                else
                {
                    TempData["Message"] = "Password tidak sesuai!";
                    return RedirectToAction("Index", "Auth");
                }
            }
            else if (admin.Email == email)
            {
                if (admin.Password == pass)
                {
                    Response.Cookies.Append("user_id", admin.Id.ToString(), options);
                    Response.Cookies.Append("user_role", "admin", options);
                    return RedirectToAction("Index", "SCM");
                }
                else
                {
                    TempData["Message"] = "Password tidak sesuai!";
                    return RedirectToAction("Index", "Auth");
                }
            }
            else
            {
                TempData["Message"] = "Email tidak sesuai!";
                return RedirectToAction("Index", "Auth");
            }
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,Kategori,Harga,Jumlah,Minimum")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produk);
        }

        [HttpPost]
        public IActionResult DeleteCookie()
        {
            // Delete the cookie from the browser.
            Response.Cookies.Delete("Name");

            return RedirectToAction("Index");
        }
    }
}
