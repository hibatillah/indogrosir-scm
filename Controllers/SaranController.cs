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
    public class SaranController : Controller
    {
        private readonly indogrosir_tim8Context _context;

        public SaranController(indogrosir_tim8Context context)
        {
            _context = context;
        }

        // GET: Saran
        public async Task<IActionResult> Index()
        {
              return _context.Saran != null ? 
                          View(await _context.Saran.ToListAsync()) :
                          Problem("Entity set 'indogrosir_tim8Context.Saran'  is null.");
        }

        // GET: Saran/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Saran == null)
            {
                return NotFound();
            }

            var saran = await _context.Saran
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saran == null)
            {
                return NotFound();
            }

            return View(saran);
        }

        // GET: Saran/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Saran/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,NoHape,Cabang,Pesan,Tanggal")] Saran saran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saran);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Pesan berhasil dikirim!";
                return RedirectToAction(nameof(Create));
            }
            TempData["Message"] = "Pesan gagal dikirim!";
            return View(nameof(Create));
        }

        // GET: Saran/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Saran == null)
            {
                return NotFound();
            }

            var saran = await _context.Saran.FindAsync(id);
            if (saran == null)
            {
                return NotFound();
            }
            return View(saran);
        }

        // POST: Saran/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,NoHape,Cabang,Pesan,Tanggal")] Saran saran)
        {
            if (id != saran.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaranExists(saran.Id))
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
            return View(saran);
        }

        // GET: Saran/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Saran == null)
            {
                return NotFound();
            }

            var saran = await _context.Saran
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saran == null)
            {
                return NotFound();
            }

            return View(saran);
        }

        // POST: Saran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Saran == null)
            {
                return Problem("Entity set 'indogrosir_tim8Context.Saran'  is null.");
            }
            var saran = await _context.Saran.FindAsync(id);
            if (saran != null)
            {
                _context.Saran.Remove(saran);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaranExists(int id)
        {
          return (_context.Saran?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
