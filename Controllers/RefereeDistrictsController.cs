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
    public class RefereeDistrictsController : Controller
    {
        private readonly HockeyStats2019Context _context;

        public RefereeDistrictsController(HockeyStats2019Context context)
        {
            _context = context;
        }

        // GET: RefereeDistricts
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefereeDistrict.ToListAsync());
        }

        // GET: RefereeDistricts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeDistrict = await _context.RefereeDistrict
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refereeDistrict == null)
            {
                return NotFound();
            }

            return View(refereeDistrict);
        }

        // GET: RefereeDistricts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefereeDistricts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RefereeDistrictName")] RefereeDistrict refereeDistrict)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refereeDistrict);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refereeDistrict);
        }

        // GET: RefereeDistricts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeDistrict = await _context.RefereeDistrict.FindAsync(id);
            if (refereeDistrict == null)
            {
                return NotFound();
            }
            return View(refereeDistrict);
        }

        // POST: RefereeDistricts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RefereeDistrictName")] RefereeDistrict refereeDistrict)
        {
            if (id != refereeDistrict.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refereeDistrict);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefereeDistrictExists(refereeDistrict.Id))
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
            return View(refereeDistrict);
        }

        // GET: RefereeDistricts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeDistrict = await _context.RefereeDistrict
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refereeDistrict == null)
            {
                return NotFound();
            }

            return View(refereeDistrict);
        }

        // POST: RefereeDistricts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refereeDistrict = await _context.RefereeDistrict.FindAsync(id);
            _context.RefereeDistrict.Remove(refereeDistrict);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefereeDistrictExists(int id)
        {
            return _context.RefereeDistrict.Any(e => e.Id == id);
        }
    }
}
