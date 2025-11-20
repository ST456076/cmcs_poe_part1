using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cmcs_poe_part1.Data;

namespace cmcs_poe_part1.Controllers
{
    [Authorize(Roles = "AcademicManager")]
    public class ManagerClaimsController : Controller
    {
        private readonly AppDbContext _context;

        public ManagerClaimsController(AppDbContext context)
        {
            _context = context;
        }

        // Academic Manager sees only Pre-Approved claims
        public async Task<IActionResult> Index()
        {
            var claims = await _context.PreApproveClaims
                .Where(x => x.Status == "Pre-Approved")
                .ToListAsync();

            return View(claims);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var claim = await _context.PreApproveClaims.FindAsync(id);
            if (claim == null) return NotFound();

            claim.Status = "Approved";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Decline(int id)
        {
            var claim = await _context.PreApproveClaims.FindAsync(id);
            if (claim == null) return NotFound();

            claim.Status = "Declined";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

