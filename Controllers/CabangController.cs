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
    public class CabangController : Controller
    {
        private readonly indogrosir_tim8Context _context;

        public CabangController(indogrosir_tim8Context context)
        {
            _context = context;
        }

        // GET: Cabang
        public async Task<IActionResult> Index()
        {
              return _context.Cabang != null ? 
                          View(await _context.Cabang.ToListAsync()) :
                          Problem("Entity set 'indogrosir_tim8Context.Cabang'  is null.");
        }

        // GET: Cabang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cabang == null)
            {
                return NotFound();
            }

            var cabang = await _context.Cabang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cabang == null)
            {
                return NotFound();
            }

            return View(cabang);
        }

        // GET: Cabang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cabang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,Lokasi,Admin,Produk,Mitra")] Cabang cabang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cabang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cabang);
        }

        // GET: Cabang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cabang == null)
            {
                return NotFound();
            }

            var cabang = await _context.Cabang.FindAsync(id);
            if (cabang == null)
            {
                return NotFound();
            }
            return View(cabang);
        }

        // POST: Cabang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,Lokasi,Admin,Produk,Mitra")] Cabang cabang)
        {
            if (id != cabang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cabang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CabangExists(cabang.Id))
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
            return View(cabang);
        }

        // GET: Cabang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cabang == null)
            {
                return NotFound();
            }

            var cabang = await _context.Cabang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cabang == null)
            {
                return NotFound();
            }

            return View(cabang);
        }

        // POST: Cabang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cabang == null)
            {
                return Problem("Entity set 'indogrosir_tim8Context.Cabang'  is null.");
            }
            var cabang = await _context.Cabang.FindAsync(id);
            if (cabang != null)
            {
                _context.Cabang.Remove(cabang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CabangExists(int id)
        {
          return (_context.Cabang?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
