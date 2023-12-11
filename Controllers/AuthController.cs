using indogrosir_tim8.Data;
using Microsoft.AspNetCore.Mvc;

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

        //public async Task<IActionResult> Index(string email, string pass)
        //{
        //    if (_context.Mitra == null)
        //    {
        //        return Problem("Entity set 'Mitra' is null.");
        //    }
        //    var mitra = from m in _context.Mitra
        //                 select m;

        //    if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(pass))
        //    {
        //        if (mitra.Where(s => s.Email == email && s.Password == pass))
        //        {

        //        }
        //    }
        //}

        public IActionResult Signup()
        {
            return View();
        }
    }
}
