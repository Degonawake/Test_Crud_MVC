using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crud.Models.Entities;

namespace crud.Controllers
{
    public class GradesController : Controller
    {
        private readonly StudentsContext _context;

        public GradesController(StudentsContext context)
        {
            _context = context;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
              return _context.Grade != null ? 
                          View(await _context.Grade.ToListAsync()) :
                          Problem("Entity set 'StudentsContext.Grade'  is null.");
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grade == null)
            {
                return NotFound();
            }

            var grades = await _context.Grade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grades == null)
            {
                return NotFound();
            }

            return View(grades);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grade")] Grades grades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grades);
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grade == null)
            {
                return NotFound();
            }

            var grades = await _context.Grade.FindAsync(id);
            if (grades == null)
            {
                return NotFound();
            }
            return View(grades);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Grade")] Grades grades)
        {
            if (id != grades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradesExists(grades.Id))
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
            return View(grades);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grade == null)
            {
                return NotFound();
            }

            var grades = await _context.Grade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grades == null)
            {
                return NotFound();
            }

            return View(grades);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grade == null)
            {
                return Problem("Entity set 'StudentsContext.Grade'  is null.");
            }
            var grades = await _context.Grade.FindAsync(id);
            if (grades != null)
            {
                _context.Grade.Remove(grades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradesExists(int id)
        {
          return (_context.Grade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
