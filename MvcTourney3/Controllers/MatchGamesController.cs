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
    public class MatchGamesController : Controller
    {
        private readonly MvcTourney3Context _context;

        public MatchGamesController(MvcTourney3Context context)
        {
            _context = context;
        }

        // GET: MatchGames
        public async Task<IActionResult> Index()
        {
            var matchgame = _context.MatchGames
          .Include(s => s.Team1)
          .Include(s => s.Team2)
          .AsNoTracking();
            return View(matchgame);
            
        }

        // GET: MatchGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MatchGames == null)
            {
                return NotFound();
            }

            var matchGames = await _context.MatchGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchGames == null)
            {
                return NotFound();
            }

            return View(matchGames);
        }

        // GET: MatchGames/Create
        public IActionResult Create()
        {
            ViewBag.Team = _context.Team;
            return View();
        }

        // POST: MatchGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Result,Team1Score,Team2Score,Team1Id,Team2Id")] MatchGames matchGames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matchGames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matchGames);
        }

        // GET: MatchGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MatchGames == null)
            {
                return NotFound();
            }

            var matchGames = await _context.MatchGames.FindAsync(id);
            if (matchGames == null)
            {
                return NotFound();
            }
            ViewBag.Team = _context.Team;
            return View(matchGames);
        }

        // POST: MatchGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Result,Team1Score,Team2Score,Team1Id,Team2Id")] MatchGames matchGames)
        {
            if (id != matchGames.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchGames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchGamesExists(matchGames.Id))
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
            return View(matchGames);
        }

        // GET: MatchGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MatchGames == null)
            {
                return NotFound();
            }

            var matchGames = await _context.MatchGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchGames == null)
            {
                return NotFound();
            }

            return View(matchGames);
        }

        // POST: MatchGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MatchGames == null)
            {
                return Problem("Entity set 'MvcTourney3Context.MatchGames'  is null.");
            }
            var matchGames = await _context.MatchGames.FindAsync(id);
            if (matchGames != null)
            {
                _context.MatchGames.Remove(matchGames);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchGamesExists(int id)
        {
          return _context.MatchGames.Any(e => e.Id == id);
        }
    }
}
