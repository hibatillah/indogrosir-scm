using indogrosir_tim8.Data;
using indogrosir_tim8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace indogrosir_tim8.Controllers
{
    public class TentangController : Controller
    {
        private readonly indogrosir_tim8Context _context;

        public TentangController(indogrosir_tim8Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sejarah()
        {
            return View();
        }
    }
}
