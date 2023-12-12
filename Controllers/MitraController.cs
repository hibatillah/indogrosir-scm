﻿using System;
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

        public MitraController(indogrosir_tim8Context context)
        {
            _context = context;
        }

        // GET: Mitra
        public async Task<IActionResult> Index(string searchMitra)
        {
            if (_context.Mitra == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie' is null.");
            }
            var mitra = from m in _context.Mitra
                         select m;
            if (!String.IsNullOrEmpty(searchMitra))
            {
                mitra = mitra.Where(s => s.Nama!.Contains(searchMitra));
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
        public async Task<IActionResult> Create([Bind("Id,Nama,Alamat,Cabang,TahunBerdiri,GabungMember,Admin,Email,Password")] Mitra mitra)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,Alamat,Cabang,TahunBerdiri,GabungMember,Admin,Email,Password,Produk")] Mitra mitra)
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
                return RedirectToAction(nameof(Index));
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
