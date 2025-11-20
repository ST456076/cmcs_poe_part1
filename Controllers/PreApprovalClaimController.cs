using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cmcs_poe_part1.Data;

namespace cmcs_poe_part1.Controllers
{
    [Authorize(Roles = "ProgramCoordinator")]
    public class PreApproveClaimController : Controller
    {
        private readonly AppDbContext _context;

        public PreApproveClaimController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ClaimReport()
        {
            var claims = await _context.PreApproveClaims.ToListAsync();
            return View(claims);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PreApprove(int id)
        {
            var claim = await _context.PreApproveClaims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }

            claim.Status = "Pre-Approved";
            _context.Update(claim);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ClaimReport));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(int id)
        {
            var claim = await _context.PreApproveClaims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }

            claim.Status = "Declined";
            _context.Update(claim);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ClaimReport));
        }
    }
}