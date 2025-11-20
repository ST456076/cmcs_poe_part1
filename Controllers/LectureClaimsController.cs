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

        // GET: LectureClaims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LectureClaims/Create
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
    }
}
