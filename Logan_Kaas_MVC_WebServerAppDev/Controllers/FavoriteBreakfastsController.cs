using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Logan_Kaas_MVC_WebServerAppDev.Data;
using Logan_Kaas_MVC_WebServerAppDev.Entities;

namespace Logan_Kaas_MVC_WebServerAppDev.Controllers
{
    public class FavoriteBreakfastsController : Controller
    {
        private readonly DBContext _context;

        public FavoriteBreakfastsController(DBContext context)
        {
            _context = context;
        }

        // GET: FavoriteBreakfasts
        public async Task<IActionResult> Index()
        {
            return View(await _context.FavoriteBreakfast.ToListAsync());
        }

        // GET: FavoriteBreakfasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteBreakfast = await _context.FavoriteBreakfast
                .FirstOrDefaultAsync(m => m.FavoriteBreakfastId == id);
            if (favoriteBreakfast == null)
            {
                return NotFound();
            }

            return View(favoriteBreakfast);
        }

        // GET: FavoriteBreakfasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavoriteBreakfasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoriteBreakfastId,FirstName,LastName,FavoriteBreakfastFood")] FavoriteBreakfast favoriteBreakfast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteBreakfast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favoriteBreakfast);
        }

        // GET: FavoriteBreakfasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteBreakfast = await _context.FavoriteBreakfast.FindAsync(id);
            if (favoriteBreakfast == null)
            {
                return NotFound();
            }
            return View(favoriteBreakfast);
        }

        // POST: FavoriteBreakfasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoriteBreakfastId,FirstName,LastName,FavoriteBreakfastFood")] FavoriteBreakfast favoriteBreakfast)
        {
            if (id != favoriteBreakfast.FavoriteBreakfastId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteBreakfast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteBreakfastExists(favoriteBreakfast.FavoriteBreakfastId))
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
            return View(favoriteBreakfast);
        }

        // GET: FavoriteBreakfasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteBreakfast = await _context.FavoriteBreakfast
                .FirstOrDefaultAsync(m => m.FavoriteBreakfastId == id);
            if (favoriteBreakfast == null)
            {
                return NotFound();
            }

            return View(favoriteBreakfast);
        }

        // POST: FavoriteBreakfasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteBreakfast = await _context.FavoriteBreakfast.FindAsync(id);
            if (favoriteBreakfast != null)
            {
                _context.FavoriteBreakfast.Remove(favoriteBreakfast);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteBreakfastExists(int id)
        {
            return _context.FavoriteBreakfast.Any(e => e.FavoriteBreakfastId == id);
        }
    }
}
