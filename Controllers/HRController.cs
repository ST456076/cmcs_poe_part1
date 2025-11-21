using cmcs_poe_part1.Data;
using cmcs_poe_part1.Models;
using cmcs_poe_part1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cmcs_poe_part1.Controllers
{
    public class HRController : Controller
    {
        private readonly ClaimApprovalWorkflow _claimApprovalWorkflow;
        private readonly AppDbContext _context;

        public HRController(ClaimApprovalWorkflow claimApprovalWorkflow, AppDbContext context)
        {
            _claimApprovalWorkflow = claimApprovalWorkflow;
            _context = context;
        }

        // GET: HR
        public async Task<IActionResult> Index()
        {
            var lecturers = await _context.Lecturers.ToListAsync();
            return View(lecturers);
        }

        // GET: HR/Claims
        public async Task<IActionResult> Claims(int lecturerId)
        {
            var claims = await _context.Lecturers
                .Where(c => c.LecturerId == lecturerId)
                .ToListAsync();

            return View(claims);
        }


            // POST: HR/ApproveClaim
            [HttpPost]
            public async Task<IActionResult> ApproveClaim(int claimId)
            {
                var claim = await _context.Lecturers.FindAsync(claimId);

                if (claim != null)
                {
                    await _claimApprovalWorkflow.ApproveClaim(claim);
                    return RedirectToAction("Claims", new { lecturerId = claim.LecturerId });
                }

                return NotFound();
            }
        

        // POST: HR/RejectClaim
        [HttpPost]
        public async Task<IActionResult> RejectClaim(int claimId)
        {
            var claim = await _context.Lecturers.FindAsync(claimId);

                if (claim != null)
                {
                    await _claimApprovalWorkflow.RejectClaim(claim);
                    return RedirectToAction("Claims", new { lecturerId = claim.LecturerId });
                }

                return NotFound();
            }
        

        // GET: HR/Invoice
        public async Task<IActionResult> Invoice(int claimId)
        {
            var claim = await _context.Lecturers.FindAsync(claimId);

            if (claim != null)
            {
                var invoice = await _claimApprovalWorkflow.GenerateInvoice(claim);
                return View(invoice);
            }

            return NotFound();
        }
    }
}
    