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
    public class PeopleController : Controller
    {
        private readonly HockeyStats2019Context _context;

        public PeopleController(HockeyStats2019Context context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var hockeyStats2019Context = _context.Person.Include(p => p.RefereeCategory).Include(p => p.RefereeCategoryType).Include(p => p.RefereeDistrict).Include(p => p.RefereeType);
            return View(await hockeyStats2019Context.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.RefereeCategory)
                .Include(p => p.RefereeCategoryType)
                .Include(p => p.RefereeDistrict)
                .Include(p => p.RefereeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["RefereeCategoryId"] = new SelectList(_context.Set<RefereeCategory>(), "Id", "RefereeCategoryName");
            ViewData["RefereeCategoryTypeId"] = new SelectList(_context.Set<RefereeCategoryType>(), "Id", "RefereeCategoryTypeName");
            ViewData["RefereeDistrictId"] = new SelectList(_context.Set<RefereeDistrict>(), "Id", "RefereeDistrictName");
            ViewData["RefereeTypeId"] = new SelectList(_context.Set<RefereeType>(), "Id", "RefereeTypeName");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,StreetAddress,ZipCode,County,Country,Ssn,PhoneNumber,Email,RefereeNumber,RefereeTypeId,RefereeCategoryId,RefereeCategoryTypeId,RefereeDistrictId,IsReferee,IsHeadcoach,IsAssistingCoach,IsAssistingPlayer")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RefereeCategoryId"] = new SelectList(_context.Set<RefereeCategory>(), "Id", "RefereeCategoryName", person.RefereeCategoryId);
            ViewData["RefereeCategoryTypeId"] = new SelectList(_context.Set<RefereeCategoryType>(), "Id", "RefereeCategoryTypeName", person.RefereeCategoryTypeId);
            ViewData["RefereeDistrictId"] = new SelectList(_context.Set<RefereeDistrict>(), "Id", "RefereeDistrictName", person.RefereeDistrictId);
            ViewData["RefereeTypeId"] = new SelectList(_context.Set<RefereeType>(), "Id", "RefereeTypeName", person.RefereeTypeId);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["RefereeCategoryId"] = new SelectList(_context.Set<RefereeCategory>(), "Id", "RefereeCategoryName", person.RefereeCategoryId);
            ViewData["RefereeCategoryTypeId"] = new SelectList(_context.Set<RefereeCategoryType>(), "Id", "RefereeCategoryTypeName", person.RefereeCategoryTypeId);
            ViewData["RefereeDistrictId"] = new SelectList(_context.Set<RefereeDistrict>(), "Id", "RefereeDistrictName", person.RefereeDistrictId);
            ViewData["RefereeTypeId"] = new SelectList(_context.Set<RefereeType>(), "Id", "RefereeTypeName", person.RefereeTypeId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,StreetAddress,ZipCode,County,Country,Ssn,PhoneNumber,Email,RefereeNumber,RefereeTypeId,RefereeCategoryId,RefereeCategoryTypeId,RefereeDistrictId,IsReferee,IsHeadcoach,IsAssistingCoach,IsAssistingPlayer")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["RefereeCategoryId"] = new SelectList(_context.Set<RefereeCategory>(), "Id", "RefereeCategoryName", person.RefereeCategoryId);
            ViewData["RefereeCategoryTypeId"] = new SelectList(_context.Set<RefereeCategoryType>(), "Id", "RefereeCategoryTypeName", person.RefereeCategoryTypeId);
            ViewData["RefereeDistrictId"] = new SelectList(_context.Set<RefereeDistrict>(), "Id", "RefereeDistrictName", person.RefereeDistrictId);
            ViewData["RefereeTypeId"] = new SelectList(_context.Set<RefereeType>(), "Id", "RefereeTypeName", person.RefereeTypeId);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.RefereeCategory)
                .Include(p => p.RefereeCategoryType)
                .Include(p => p.RefereeDistrict)
                .Include(p => p.RefereeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
