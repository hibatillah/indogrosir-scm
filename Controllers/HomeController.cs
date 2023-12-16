using indogrosir_tim8.Data;
using indogrosir_tim8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace indogrosir_tim8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly indogrosir_tim8Context _context;

        public HomeController(ILogger<HomeController> logger, indogrosir_tim8Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Berita()
        {
            return View();
        }

        public async Task<IActionResult> Lokasi()
        {
            var cabang = from m in _context.Mitra
                         select m;
            return View(await cabang.ToListAsync());
      
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}