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
    public class TeachersSchedulesController : Controller
    {
        private readonly StudentsContext _context;

        public TeachersSchedulesController(StudentsContext context)
        {
            _context = context;
        }

        // GET: TeachersSchedules
        public async Task<IActionResult> Index()
        {
              return _context.TeacherSchedule != null ? 
                          View(await _context.TeacherSchedule.ToListAsync()) :
                          Problem("Entity set 'StudentsContext.TeacherSchedule'  is null.");
        }

        // GET: TeachersSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeacherSchedule == null)
            {
                return NotFound();
            }

            var teachersSchedule = await _context.TeacherSchedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachersSchedule == null)
            {
                return NotFound();
            }

            return View(teachersSchedule);
        }

        // GET: TeachersSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeachersSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,GradeId,SubjectId,ClassroomId,Schedule")] TeachersSchedule teachersSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachersSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teachersSchedule);
        }

        // GET: TeachersSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeacherSchedule == null)
            {
                return NotFound();
            }

            var teachersSchedule = await _context.TeacherSchedule.FindAsync(id);
            if (teachersSchedule == null)
            {
                return NotFound();
            }
            return View(teachersSchedule);
        }

        // POST: TeachersSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,GradeId,SubjectId,ClassroomId,Schedule")] TeachersSchedule teachersSchedule)
        {
            if (id != teachersSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachersSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersScheduleExists(teachersSchedule.Id))
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
            return View(teachersSchedule);
        }

        // GET: TeachersSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeacherSchedule == null)
            {
                return NotFound();
            }

            var teachersSchedule = await _context.TeacherSchedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachersSchedule == null)
            {
                return NotFound();
            }

            return View(teachersSchedule);
        }

        // POST: TeachersSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeacherSchedule == null)
            {
                return Problem("Entity set 'StudentsContext.TeacherSchedule'  is null.");
            }
            var teachersSchedule = await _context.TeacherSchedule.FindAsync(id);
            if (teachersSchedule != null)
            {
                _context.TeacherSchedule.Remove(teachersSchedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachersScheduleExists(int id)
        {
          return (_context.TeacherSchedule?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
