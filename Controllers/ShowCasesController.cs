using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HockeyStats2019.Models;

namespace HockeyStats2019.Controllers
{
    public class ShowCasesController : Controller
    {
        private readonly HockeyStats2019Context _context;

        public ShowCasesController(HockeyStats2019Context context)
        {
            _context = context;
        }

        // GET: ShowCases
        public async Task<IActionResult> Index()
        {
            var hockeyStats2019Context = _context.ShowCase.Include(s => s.AgeCategory).Include(s => s.Arena).Include(s => s.Coach).Include(s => s.Coach1).Include(s => s.Coach2).Include(s => s.Coach3).Include(s => s.GeneralManager).Include(s => s.Location).Include(s => s.Referee);
            return View(await hockeyStats2019Context.ToListAsync());
        }

        // GET: ShowCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showCase = await _context.ShowCase
                .Include(s => s.AgeCategory)
                .Include(s => s.Arena)
                .Include(s => s.Coach)
                .Include(s => s.Coach1)
                .Include(s => s.Coach2)
                .Include(s => s.Coach3)
                .Include(s => s.GeneralManager)
                .Include(s => s.Location)
                .Include(s => s.Referee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showCase == null)
            {
                return NotFound();
            }

            return View(showCase);
        }

        // GET: ShowCases/Create
        public IActionResult Create()
        {
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName");
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId5"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["ArenaId1"] = new SelectList(_context.Arena, "Id", "ArenaAddress");
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: ShowCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,ShowCaseName,ArenaId,SeriesId,ArenaId1,PersonId,PersonId1,PersonId2,PersonId3,PersonId4,PersonId5")] ShowCase showCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", showCase.SeriesId);
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", showCase.ArenaId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId3);
            ViewData["PersonId5"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId5);
            ViewData["ArenaId1"] = new SelectList(_context.Arena, "Id", "ArenaAddress", showCase.ArenaId1);
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId4);
            return View(showCase);
        }

        // GET: ShowCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showCase = await _context.ShowCase.FindAsync(id);
            if (showCase == null)
            {
                return NotFound();
            }
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", showCase.SeriesId);
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", showCase.ArenaId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId3);
            ViewData["PersonId5"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId5);
            ViewData["ArenaId1"] = new SelectList(_context.Arena, "Id", "ArenaAddress", showCase.ArenaId1);
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId4);
            return View(showCase);
        }

        // POST: ShowCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,ShowCaseName,ArenaId,SeriesId,ArenaId1,PersonId,PersonId1,PersonId2,PersonId3,PersonId4,PersonId5")] ShowCase showCase)
        {
            if (id != showCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowCaseExists(showCase.Id))
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
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", showCase.SeriesId);
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", showCase.ArenaId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId3);
            ViewData["PersonId5"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId5);
            ViewData["ArenaId1"] = new SelectList(_context.Arena, "Id", "ArenaAddress", showCase.ArenaId1);
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName", showCase.PersonId4);
            return View(showCase);
        }

        // GET: ShowCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showCase = await _context.ShowCase
                .Include(s => s.AgeCategory)
                .Include(s => s.Arena)
                .Include(s => s.Coach)
                .Include(s => s.Coach1)
                .Include(s => s.Coach2)
                .Include(s => s.Coach3)
                .Include(s => s.GeneralManager)
                .Include(s => s.Location)
                .Include(s => s.Referee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showCase == null)
            {
                return NotFound();
            }

            return View(showCase);
        }

        // POST: ShowCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showCase = await _context.ShowCase.FindAsync(id);
            _context.ShowCase.Remove(showCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowCaseExists(int id)
        {
            return _context.ShowCase.Any(e => e.Id == id);
        }
    }
}
