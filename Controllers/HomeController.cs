using indogrosir_tim8.Data;
using indogrosir_tim8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace indogrosir_tim8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly indogrosir_tim8Context _context;
        private readonly IHttpContextAccessor _accessor;

        public HomeController(ILogger<HomeController> logger, indogrosir_tim8Context context, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _context = context;
            _accessor = accessor;
        }


        public IActionResult Index()
        {
            string user_id = _accessor.HttpContext.Request.Cookies["user_id"];
            string user_role = _accessor.HttpContext.Request.Cookies["user_role"];

            if (user_id != null && user_role != null)
            {
                return RedirectToAction("Index", "SCM");
            }
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}