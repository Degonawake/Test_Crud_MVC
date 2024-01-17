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
    public class TeacherSchedulesController : Controller
    {
        private readonly StudentsContext _context;

        public TeacherSchedulesController(StudentsContext context)
        {
            _context = context;
        }

        // GET: TeacherSchedules
        public async Task<IActionResult> Index()
        {
              return _context.TeacherSchedule != null ? 
                          View(await _context.TeacherSchedule.ToListAsync()) :
                          Problem("Entity set 'StudentsContext.TeacherSchedule'  is null.");
        }

        // GET: TeacherSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeacherSchedule == null)
            {
                return NotFound();
            }

            var teacherSchedule = await _context.TeacherSchedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherSchedule == null)
            {
                return NotFound();
            }

            return View(teacherSchedule);
        }

        // GET: TeacherSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,GradeId,SubjectId,ClassroomId,Schedule")] TeacherSchedule teacherSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherSchedule);
        }

        // GET: TeacherSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeacherSchedule == null)
            {
                return NotFound();
            }

            var teacherSchedule = await _context.TeacherSchedule.FindAsync(id);
            if (teacherSchedule == null)
            {
                return NotFound();
            }
            return View(teacherSchedule);
        }

        // POST: TeacherSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,GradeId,SubjectId,ClassroomId,Schedule")] TeacherSchedule teacherSchedule)
        {
            if (id != teacherSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherScheduleExists(teacherSchedule.Id))
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
            return View(teacherSchedule);
        }

        // GET: TeacherSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeacherSchedule == null)
            {
                return NotFound();
            }

            var teacherSchedule = await _context.TeacherSchedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherSchedule == null)
            {
                return NotFound();
            }

            return View(teacherSchedule);
        }

        // POST: TeacherSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeacherSchedule == null)
            {
                return Problem("Entity set 'StudentsContext.TeacherSchedule'  is null.");
            }
            var teacherSchedule = await _context.TeacherSchedule.FindAsync(id);
            if (teacherSchedule != null)
            {
                _context.TeacherSchedule.Remove(teacherSchedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherScheduleExists(int id)
        {
          return (_context.TeacherSchedule?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
