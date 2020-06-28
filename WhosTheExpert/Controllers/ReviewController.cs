using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhosTheExpert.Models;

namespace WhosTheExpert.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ReviewController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Reviews.ToList());
        }

        public async Task<IActionResult> Create(Review review)
        {
            if (ModelState.IsValid)
            {
                _db.Add(review);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // Review/Details/3
        public ActionResult Details(int id)              // GET
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Reviews = _db.Reviews.SingleOrDefault(m => m.Id == id);
            if (Reviews == null)
            {
                return NotFound();
            }
            return View(Reviews);
        }

        // POST
        // Details - none

        public async Task<IActionResult> Delete(int? id) // GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var Reviews = await _db.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (Reviews == null)
            {
                return NotFound();
            }
            return View(Reviews);
        }

        [HttpPost]                                 // POST
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var Reviews = await _db.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            _db.Reviews.Remove(Reviews);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id) // GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var Reviews = await _db.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (Reviews == null)
            {
                return NotFound();
            }
            return View(Reviews);
        }

        [HttpPost]                                  // POST
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(review);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}