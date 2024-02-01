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
    public class HobbiesController : Controller
    {
        private readonly DBContext _context;

        public HobbiesController(DBContext context)
        {
            _context = context;
        }

        // GET: Hobbies
        public async Task<IActionResult> Index()
        {
            Console.WriteLine(_context.Hobbies);
            return View(await _context.Hobbies.ToListAsync());
        }

        // GET: Hobbies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobbies = await _context.Hobbies
                .FirstOrDefaultAsync(m => m.HobbyId == id);
            if (hobbies == null)
            {
                return NotFound();
            }

            return View(hobbies);
        }

        // GET: Hobbies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hobbies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HobbyId,FirstName,LastName,FavoriteHobby")] Hobbies hobbies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hobbies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hobbies);
        }

        // GET: Hobbies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobbies = await _context.Hobbies.FindAsync(id);
            if (hobbies == null)
            {
                return NotFound();
            }
            return View(hobbies);
        }

        // POST: Hobbies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HobbyId,FirstName,LastName,FavoriteHobby")] Hobbies hobbies)
        {
            if (id != hobbies.HobbyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hobbies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HobbiesExists(hobbies.HobbyId))
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
            return View(hobbies);
        }

        // GET: Hobbies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobbies = await _context.Hobbies
                .FirstOrDefaultAsync(m => m.HobbyId == id);
            if (hobbies == null)
            {
                return NotFound();
            }

            return View(hobbies);
        }

        // POST: Hobbies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hobbies = await _context.Hobbies.FindAsync(id);
            if (hobbies != null)
            {
                _context.Hobbies.Remove(hobbies);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HobbiesExists(int id)
        {
            return _context.Hobbies.Any(e => e.HobbyId == id);
        }
    }
}
