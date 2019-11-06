using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhosTheExpert.Models;

namespace WhosTheExpert.Controllers
{
    public class ProfessionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProfessionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Professions.ToList());
        }

        public IActionResult Create() // GET
        {
            return View();
        }

        [HttpPost]                   // POST
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profession profession)
        {
            if (ModelState.IsValid)
            {
                _db.Add(profession);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id) // GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var Profession = await _db.Professions.SingleOrDefaultAsync(m => m.Id == id);
            if (Profession == null)
            {
                return NotFound();
            }
            return View(Profession);
        }

        // POST
        // Details - none

        public async Task<IActionResult> Delete(int? id) // GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var Profession = await _db.Professions.SingleOrDefaultAsync(m => m.Id == id);
            if (Profession == null)
            {
                return NotFound();
            }
            return View(Profession);
        }

        [HttpPost]                                 // POST
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var Profession = await _db.Professions.SingleOrDefaultAsync(m => m.Id == id);
            _db.Professions.Remove(Profession);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id) // GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var Profession = await _db.Professions.SingleOrDefaultAsync(m => m.Id == id);
            if (Profession == null)
            {
                return NotFound();
            }
            return View(Profession);
        }

        [HttpPost]                                  // POST
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Profession profession)
        {
            if (id != profession.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(profession);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        protected override void Dispose( bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}