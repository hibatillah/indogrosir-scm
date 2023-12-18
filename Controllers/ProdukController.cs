using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using indogrosir_tim8.Models;
using indogrosir_tim8.Data;

namespace indogrosir_tim8.Controllers
{
    public class ProdukController : Controller
    {
        private readonly indogrosir_tim8Context _context;

        public ProdukController(indogrosir_tim8Context context)
        {
            _context = context;
        }

        // GET: Produk
        public async Task<IActionResult> Index(string searchProduk)
        {
            if (_context.Produk == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie' is null.");
            }
            var produk = from m in _context.Produk
                         select m;
            if (!String.IsNullOrEmpty(searchProduk))
            {
                produk = produk.Where(s => s.Nama!.Contains(searchProduk));
            }
            return View(await produk.ToListAsync());
            
        }

        // GET: Produk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produk == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk
                .FirstOrDefaultAsync(m => m.Id == id);

            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // GET: Produk/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,Kategori,Harga,Jumlah,Minimum,UserId,UserRole")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produk);
        }

        // GET: Produk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produk == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk.FindAsync(id);
            if (produk == null)
            {
                return NotFound();
            }
            return View(produk);
        }

        // POST: Produk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,Kategori,Harga,Jumlah,Minimum")] Produk produk)
        {
            if (id != produk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukExists(produk.Id))
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
            return View(produk);
        }

        // GET: Produk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produk == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // POST: Produk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produk == null)
            {
                return Problem("Entity set 'indogrosir_tim8Context.Produk'  is null.");
            }
            var produk = await _context.Produk.FindAsync(id);
            if (produk != null)
            {
                _context.Produk.Remove(produk);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukExists(int id)
        {
          return (_context.Produk?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Keranjang()
        {
            return _context.Produk != null ?
                          View(await _context.Produk.ToListAsync()) :
                          Problem("Entity set 'indogrosir_tim8Context.Produk'  is null.");
        }
        public async Task<IActionResult> List(string searchListProduk)
        {
            if (_context.Produk == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie' is null.");
            }
            var produk = from m in _context.Produk
                         select m;
            if (!String.IsNullOrEmpty(searchListProduk))
            {
                produk = produk.Where(s => s.Nama!.Contains(searchListProduk));
            }
            return View(await produk.ToListAsync());

        }
    }
}
