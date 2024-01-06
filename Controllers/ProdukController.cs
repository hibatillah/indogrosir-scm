using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using indogrosir_tim8.Models;
using indogrosir_tim8.Data;
using Microsoft.Extensions.Hosting;

namespace indogrosir_tim8.Controllers
{
    public class ProdukController : Controller
    {
        private readonly indogrosir_tim8Context _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProdukController(indogrosir_tim8Context context, IHttpContextAccessor accessor, IWebHostEnvironment hc)
        {
            _context = context;
            _accessor = accessor;
            _hostEnvironment = hc;
        }

        // GET: Produk
        public async Task<IActionResult> Index(string searchProduk)
        {
            string user_id = _accessor.HttpContext.Request.Cookies["user_id"];
            string user_role = _accessor.HttpContext.Request.Cookies["user_role"];

            if (_context.Produk == null)
            {
                return Problem("Entity set 'Produk' is null.");
            }

            var produk = from m in _context.Produk
                         select m;

            // get produk by login user
            var produk_user = produk.Where(s => s.UserId.ToString() == user_id && s.UserRole == user_role);

            if (!String.IsNullOrEmpty(searchProduk))
            {
                produk_user = produk_user.Where(s => s.Nama!.Contains(searchProduk));
            }
            
            if (produk_user != null)
            {
                return View(await produk_user.ToListAsync()); 
            }
            else
            {
                return View(await produk.ToListAsync());
            }
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
            ViewData["ImagePath"] = Path.Combine("/assets/produk", produk.Gambar);
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
        public async Task<IActionResult> Create(ProdukViewModel produk)
        {
            if (ModelState.IsValid) // Validasi model
            {
                String filename = "";
                if (produk.Gambar != null)
                {
                    String uploadfolder = Path.Combine(_hostEnvironment.WebRootPath, "assets/produk");
                    filename = Guid.NewGuid().ToString() + "_" + produk.Gambar.FileName;
                    String filepath = Path.Combine(uploadfolder, filename);
                    produk.Gambar.CopyTo(new FileStream(filepath, FileMode.Create));
                }

                Produk p = new Produk
                {
                    Nama = produk.Nama,
                    Gambar = filename,
                    Harga = produk.Harga,
                    Kategori = produk.Kategori,
                    Minimum = produk.Minimum,
                    Jumlah = produk.Jumlah,
                    UserId = produk.UserId,
                    UserRole = produk.UserRole,
                };

                _context.Produk.Add(p);
                await _context.SaveChangesAsync(); // Menggunakan SaveChangesAsync()

                ViewBag.Success = "Record added";
                TempData["Message"] = "Data Berhasil dibuat";
                // Alihkan ke action Index
                return RedirectToAction("Index");

               
            }
            TempData["Message"] = "Data gagal dibuat";
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
            ViewData["ImagePath"] = Path.Combine("/assets/produk", produk.Gambar);

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
