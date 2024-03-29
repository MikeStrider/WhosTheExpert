﻿using System;
using System.Collections.Generic;
using System.Dynamic;
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
            return View(_db.Professions.FromSql("select * from Professions").ToList());
        }

        public IActionResult Create()                  // GET
        {
            return View();
        }

        [HttpPost]                                  // POST
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

        // Profession/Details/3
        public ActionResult Details(int id)              // GET
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Reviews = _db.Reviews.FromSql("select * from Reviews Where ProfessionId = {0}", id).ToList();
            var Profession = _db.Professions.SingleOrDefault(m => m.Id == id);
            dynamic myModel = new ExpandoObject();
            myModel.Reviews = Reviews;
            myModel.Profession = Profession;
            if (Profession == null)
            {
                return NotFound();
            }
            return View(myModel);
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
            return View(profession);
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