using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using indogrosir_tim8.Data;
using indogrosir_tim8.Models;

namespace indogrosir_tim8.Controllers
{
    public class MitraController : Controller
    {
        private readonly indogrosir_tim8Context _context;
        private readonly IHttpContextAccessor _accessor;

        public MitraController(indogrosir_tim8Context context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public async Task<IActionResult> Dashboard()
        {
            string user_id = _accessor.HttpContext.Request.Cookies["user_id"];
            string user_role = _accessor.HttpContext.Request.Cookies["user_role"];


            if (_context.Mitra == null)
            {
                return NotFound();
            }

            if (user_role == "mitra")
            {
                var mitra = await _context.Mitra
                    .FirstOrDefaultAsync(m => m.Id.ToString() == user_id);

                var produk = from m in _context.Produk
                             select m;

                produk = produk.Where(p => p.UserId.ToString() == user_id && p.UserRole == user_role);

                var pesanan = from m in _context.Pesanan
                             select m;

                pesanan = pesanan.Where(p => p.UserId.ToString() == user_id);

                dynamic Dashboard = new System.Dynamic.ExpandoObject();
                Dashboard.Produk = produk;
                Dashboard.Mitra = mitra;
                Dashboard.Pesanan = pesanan;

                if (mitra == null)
                {
                    return NotFound();
                }

                return View(Dashboard);
            }

            TempData["Message"] = "User tidak sesuai!";
            return RedirectToAction("Logout", "Auth");
        }

        public async Task<IActionResult> Profil()
        {
            string user_id = _accessor.HttpContext.Request.Cookies["user_id"];
            string user_role = _accessor.HttpContext.Request.Cookies["user_role"];


            if (_context.Mitra == null)
            {
                return NotFound();
            }

            if (user_role == "mitra")
            {
                var mitra = await _context.Mitra
                    .FirstOrDefaultAsync(m => m.Id.ToString() == user_id);

                if (mitra == null)
                {
                    return NotFound();
                }

                return View(mitra);
            }

            TempData["Message"] = "User tidak sesuai!";
            return RedirectToAction("Index", "SCM");
        }

        public async Task<IActionResult> EditProfil()
        {
            string user_id = _accessor.HttpContext.Request.Cookies["user_id"];
            int id = int.Parse(user_id);

            if (_context.Mitra == null)
            {
                return NotFound();
            }

            var mitra = await _context.Mitra.FindAsync(id);
            if (mitra == null)
            {
                return NotFound();
            }
            return View(mitra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfil(int id, [Bind("Id,Nama,Alamat,Cabang,TahunBerdiri,GabungMember,Admin,Email")] Mitra mitra)
        {
            if (id != mitra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mitra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MitraExists(mitra.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Profil", "Mitra");
            }
            TempData["Message"] = "Data tidak valid!";
            return View(mitra);
        }

        // GET: Mitra
        public async Task<IActionResult> Index(string searchMitra)
        {
            if (_context.Mitra == null)
            {
                return Problem("Entity set 'Mitra' is null.");
            }

            string user_id = _accessor.HttpContext.Request.Cookies["user_id"];

            // get current login admin
            var admin = await _context.Admin
                        .FirstOrDefaultAsync(a => a.Id.ToString() == user_id);

            var mitra = from m in _context.Mitra
                        select m;

            // get mitra based on admin cabang
            mitra = mitra.Where(m => m.Cabang == admin.Cabang);

            if (!String.IsNullOrEmpty(searchMitra))
            {
                mitra = mitra.Where(s => s.Nama!.Contains(searchMitra) || s.Alamat!.Contains(searchMitra));
            }
            return View(await mitra.ToListAsync());
        }

        // GET: Mitra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mitra == null)
            {
                return NotFound();
            }

            var mitra = await _context.Mitra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mitra == null)
            {
                return NotFound();
            }

            return View(mitra);
        }

        // GET: Mitra/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mitra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,Alamat,Cabang,TahunBerdiri,GabungMember,Admin,Email")] Mitra mitra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mitra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mitra);
        }

        // GET: Mitra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mitra == null)
            {
                return NotFound();
            }

            var mitra = await _context.Mitra.FindAsync(id);
            if (mitra == null)
            {
                return NotFound();
            }
            return View(mitra);
        }

        // POST: Mitra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,Alamat,Cabang,TahunBerdiri,GabungMember,Admin,Email,Password")] Mitra mitra)
        {
            if (id != mitra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mitra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MitraExists(mitra.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Dashboard", "Admin");
            }
            return View(mitra);
        }

        // GET: Mitra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mitra == null)
            {
                return NotFound();
            }

            var mitra = await _context.Mitra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mitra == null)
            {
                return NotFound();
            }

            return View(mitra);
        }

        // POST: Mitra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mitra == null)
            {
                return Problem("Entity set 'indogrosir_tim8Context.Mitra'  is null.");
            }
            var mitra = await _context.Mitra.FindAsync(id);
            if (mitra != null)
            {
                _context.Mitra.Remove(mitra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MitraExists(int id)
        {
          return (_context.Mitra?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
