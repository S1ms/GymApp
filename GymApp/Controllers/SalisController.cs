using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymApp.Models;

namespace GymApp.Controllers
{
    public class SalisController : Controller
    {
        private readonly SaliDbContext _context;

        public SalisController(SaliDbContext context)
        {
            _context = context;
        }

        // GET: Salis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sali.ToListAsync());
        }

        // GET: Salis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sali = await _context.Sali
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sali == null)
            {
                return NotFound();
            }

            return View(sali);
        }

        // GET: Salis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Reps,Sets,Date")] Sali sali)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sali);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sali);
        }

        // GET: Salis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sali = await _context.Sali.FindAsync(id);
            if (sali == null)
            {
                return NotFound();
            }
            return View(sali);
        }

        // POST: Salis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Reps,Sets,Date")] Sali sali)
        {
            if (id != sali.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sali);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaliExists(sali.Id))
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
            return View(sali);
        }

        // GET: Salis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sali = await _context.Sali
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sali == null)
            {
                return NotFound();
            }

            return View(sali);
        }

        // POST: Salis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sali = await _context.Sali.FindAsync(id);
            _context.Sali.Remove(sali);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaliExists(int id)
        {
            return _context.Sali.Any(e => e.Id == id);
        }
    }
}
