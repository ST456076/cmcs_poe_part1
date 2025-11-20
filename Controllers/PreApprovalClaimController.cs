using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cmcs_poe_part1.Data;

namespace cmcs_poe_part1.Controllers
{
    [Authorize(Roles = "ProgramCoordinator")]
    public class PreApprovalClaimController : Controller
    {
        private readonly AppDbContext _context;

        public PreApprovalClaimController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ClaimReport()
        {
            // Show only pending items
            var pending = await _context.PreApproveClaims
                .Where(x => x.Status == "Pending")
                .ToListAsync();
            return View(pending);
        }

        private async Task UpdateStatusAsync(int id, string status, bool preApproved, bool declined)
        {
            var item = await _context.PreApproveClaims.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "Claim not found.";
                return;
            }

            if (item.Status != "Pending")
            {
                TempData["Error"] = "Claim is already processed.";
                return;
            }

            item.PreApproved = preApproved;
            item.Declined = declined;
            item.Status = status;
            item.PreApprovedBy = preApproved ? User?.Identity?.Name : null;
            item.PreApprovedDate = preApproved ? DateTime.UtcNow : null;
            item.DeclinedBy = declined ? User?.Identity?.Name : null;
            item.DeclinedDate = declined ? DateTime.UtcNow : null;

            _context.Update(item);
            await _context.SaveChangesAsync();
            TempData["Success"] = $"Claim {status}.";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PreApprove(int id)
        {
            await UpdateStatusAsync(id, "Pre-Approved", true, false);
            return RedirectToAction(nameof(ClaimReport));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(int id)
        {
            await UpdateStatusAsync(id, "Declined", false, true);
            return RedirectToAction(nameof(ClaimReport));
        }
    }
}