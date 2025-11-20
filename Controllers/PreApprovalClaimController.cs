using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cmcs_poe_part1.Data;
using cmcs_poe_part1.Models;
using cmcs_poe_part1.Services; // Add this namespace

namespace cmcs_poe_part1.Controllers
{
    [Authorize(Roles = "ProgramCoordinator")]
    public class PreApproveClaimController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ClaimVerificationService _claimVerificationService;
        private readonly ClaimApprovalWorkflow _claimApprovalWorkflow;

        public PreApproveClaimController(AppDbContext context, ClaimVerificationService claimVerificationService, ClaimApprovalWorkflow claimApprovalWorkflow)
        {
            _context = context;
            _claimVerificationService = claimVerificationService;
            _claimApprovalWorkflow = claimApprovalWorkflow;
        }

        // Load all claims for report
        public async Task<IActionResult> ClaimReport()
        {
            var claims = await _context.LectureClaims.ToListAsync();
            return View(claims);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PreApprove(int id)
        {
            var claim = await _context.LectureClaims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }

            bool isValid = await _claimVerificationService.VerifyClaim(claim);
            if (isValid)
            {
                await _claimApprovalWorkflow.ApproveClaim(claim);
                claim.Status = "Pre-Approved";
                _context.Update(claim);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle invalid claim
            }
            return PartialView("_ClaimStatus", claim);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(int id)
        {
            var claim = await _context.LectureClaims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }
            claim.Status = "Declined";
            _context.Update(claim);
            await _context.SaveChangesAsync();
            return PartialView("_ClaimStatus", claim);
        }
    }
}
