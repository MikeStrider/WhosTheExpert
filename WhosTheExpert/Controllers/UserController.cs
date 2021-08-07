using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhosTheExpert.Models;

namespace WhosTheExpert.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Users.ToList());
        }

        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Add(user);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> WriteReview(Review review)
        {
            if (ModelState.IsValid)
            {
                _db.Add(review);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // Users/Details/3
        public ActionResult Details(int id)              // GET
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Users = _db.Users.SingleOrDefault(m => m.Id == id);
            if (Users == null)
            {
                return NotFound();
            }
            return View(Users);
        }

        // POST
        // Details - none

        public async Task<IActionResult> Delete(int? id) // GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var Users = await _db.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (Users == null)
            {
                return NotFound();
            }
            return View(Users);
        }

        [HttpPost]                                 // POST
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var Users = await _db.Users.SingleOrDefaultAsync(m => m.Id == id);
            _db.Users.Remove(Users);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id) // GET
        {
            if (id == null)
            {
                return NotFound();
            }
            var Users = await _db.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (Users == null)
            {
                return NotFound();
            }
            return View(Users);
        }

        [HttpPost]                                  // POST
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(user);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
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