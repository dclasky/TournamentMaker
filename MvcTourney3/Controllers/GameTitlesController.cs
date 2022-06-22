using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTourney3.Data;
using MvcTourney3.Models;

namespace MvcTourney3.Controllers
{
    public class GameTitlesController : Controller
    {
        private readonly MvcTourney3Context _context;

        public GameTitlesController(MvcTourney3Context context)
        {
            _context = context;
        }

        // GET: GameTitles
        public async Task<IActionResult> Index()
        {
              return View(await _context.GameTitles.ToListAsync());
        }

        // GET: GameTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameTitles == null)
            {
                return NotFound();
            }

            var gameTitles = await _context.GameTitles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameTitles == null)
            {
                return NotFound();
            }

            return View(gameTitles);
        }

        // GET: GameTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] GameTitles gameTitles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameTitles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameTitles);
        }

        // GET: GameTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameTitles == null)
            {
                return NotFound();
            }

            var gameTitles = await _context.GameTitles.FindAsync(id);
            if (gameTitles == null)
            {
                return NotFound();
            }
            return View(gameTitles);
        }

        // POST: GameTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] GameTitles gameTitles)
        {
            if (id != gameTitles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameTitles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameTitlesExists(gameTitles.Id))
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
            return View(gameTitles);
        }

        // GET: GameTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameTitles == null)
            {
                return NotFound();
            }

            var gameTitles = await _context.GameTitles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameTitles == null)
            {
                return NotFound();
            }

            return View(gameTitles);
        }

        // POST: GameTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameTitles == null)
            {
                return Problem("Entity set 'MvcTourney3Context.GameTitles'  is null.");
            }
            var gameTitles = await _context.GameTitles.FindAsync(id);
            if (gameTitles != null)
            {
                _context.GameTitles.Remove(gameTitles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameTitlesExists(int id)
        {
          return _context.GameTitles.Any(e => e.Id == id);
        }
    }
}
