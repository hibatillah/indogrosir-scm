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

        public SCMController(indogrosir_tim8Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Mitra.ToListAsync());
        }
    }
}
