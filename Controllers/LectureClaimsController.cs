using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cmcs_poe_part1.Data;
using cmcs_poe_part1.Models;

namespace cmcs_poe_part1.Controllers
{
    public class LectureClaimsController : Controller
    {
        private readonly AppDbContext _context;

        public LectureClaimsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LectureClaims
        public async Task<IActionResult> Index()
        {
            return View(await _context.LectureClaims.ToListAsync());
        }

        // GET: LectureClaims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectureClaims = await _context.LectureClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lectureClaims == null)
            {
                return NotFound();
            }

            return View(lectureClaims);
        }

        // GET: LectureClaims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LectureClaims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameSurname,Faculty,Date,HoursWorked,HourlyRate,SupportingDocuments,Amount,WouldYouLikeToaddSomething,Status")] LectureClaims lectureClaims)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lectureClaims);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lectureClaims);
        }

        // GET: LectureClaims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectureClaims = await _context.LectureClaims.FindAsync(id);
            if (lectureClaims == null)
            {
                return NotFound();
            }
            return View(lectureClaims);
        }

        // POST: LectureClaims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameSurname,Faculty,Date,HoursWorked,HourlyRate,SupportingDocuments,Amount,WouldYouLikeToaddSomething,Status")] LectureClaims lectureClaims)
        {
            if (id != lectureClaims.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lectureClaims);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureClaimsExists(lectureClaims.Id))
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
            return View(lectureClaims);
        }

        // GET: LectureClaims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectureClaims = await _context.LectureClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lectureClaims == null)
            {
                return NotFound();
            }

            return View(lectureClaims);
        }

        // POST: LectureClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lectureClaims = await _context.LectureClaims.FindAsync(id);
            if (lectureClaims != null)
            {
                _context.LectureClaims.Remove(lectureClaims);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureClaimsExists(int id)
        {
            return _context.LectureClaims.Any(e => e.Id == id);
        }
    }
}
