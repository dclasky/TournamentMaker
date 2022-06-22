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
    public class MatchesController : Controller
    {
        private readonly MvcTourney3Context _context;

        public MatchesController(MvcTourney3Context context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            //make a var that includes the Matches table (context.Matches) and then JOINS(.Include) the table that connects to the Team1 Column
            var player = _context.Matches
            .Include(s => s.Team1)
            .Include(s => s.Team2)
            .AsNoTracking();
            return View(player);
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewBag.Team = _context.Team;
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Result,Team1W,Team2W,Team1Id,Team2Id")] Matches matches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matches);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches.FindAsync(id);
            if (matches == null)
            {
                return NotFound();
            }
            ViewBag.Team = _context.Team;
            return View(matches);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Result,Team1W,Team2W,Team1Id,Team2Id")] Matches matches)
        {
            if (id != matches.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchesExists(matches.Id))
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
            return View(matches);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Matches == null)
            {
                return Problem("Entity set 'MvcTourney3Context.Matches'  is null.");
            }
            var matches = await _context.Matches.FindAsync(id);
            if (matches != null)
            {
                _context.Matches.Remove(matches);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchesExists(int id)
        {
          return _context.Matches.Any(e => e.Id == id);
        }
    }
}
