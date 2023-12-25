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
    public class PesananController : Controller
    {
        private readonly indogrosir_tim8Context _context;
        private readonly IHttpContextAccessor _accessor;

        public PesananController(indogrosir_tim8Context context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        // GET: Pesanan
        public async Task<IActionResult> Index(string searchPesanan)
        {
            string user_id = _accessor.HttpContext.Request.Cookies["user_id"];
            string user_role = _accessor.HttpContext.Request.Cookies["user_role"];

            if (_context.Pesanan == null)
            {
                return Problem("Entity set 'Pesanan' is null.");
            }

            var pesanan = from m in _context.Pesanan
                        select m;

            // get pesanan by login user
            var pesanan_user = pesanan.Where(s => s.UserId.ToString() == user_id && s.UserRole == user_role);

            if (!String.IsNullOrEmpty(searchPesanan))
            {
                pesanan_user = pesanan_user.Where(s => s.Mitra!.Contains(searchPesanan) || s.Admin!.Contains(searchPesanan));
            }

            if (pesanan_user != null)
            {
                return View(await pesanan_user.ToListAsync());
            }
            else
            {
                return View(await pesanan.ToListAsync());
            }
        }

        // GET: Pesanan/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // GET: Pesanan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pesanan == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pesanan == null)
            {
                return NotFound();
            }

            return View(pesanan);
        }

        // POST: Pesanan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tanggal,Mitra,Cabang,Admin,Produk,TotalHarga,JumlahPesanan,UserId,UserRole")] Pesanan pesanan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesanan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pesanan);
        }

        // GET: Pesanan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pesanan == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanan.FindAsync(id);
            if (pesanan == null)
            {
                return NotFound();
            }
            return View(pesanan);
        }

        // POST: Pesanan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tanggal,Mitra,Cabang,Admin,Produk,TotalHarga,JumlahPesanan")] Pesanan pesanan)
        {
            if (id != pesanan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesanan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesananExists(pesanan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pesanan);
        }

        // GET: Pesanan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pesanan == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pesanan == null)
            {
                return NotFound();
            }

            return View(pesanan);
        }

        // POST: Pesanan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pesanan == null)
            {
                return Problem("Entity set 'indogrosir_tim8Context.Pesanan'  is null.");
            }
            var pesanan = await _context.Pesanan.FindAsync(id);
            if (pesanan != null)
            {
                _context.Pesanan.Remove(pesanan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesananExists(int id)
        {
          return (_context.Pesanan?.Any(e => e.Id == id)).GetValueOrDefault();
        }
       
    }
}
