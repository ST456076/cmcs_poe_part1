using System.Threading.Tasks;
using cmcs_poe_part1.Data;
using cmcs_poe_part1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cmcs_poe_part1.Controllers
{
    public class PendingClaimsController : Controller
    {
        private readonly AppDbContext _context;

        public PendingClaimsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PendingClaims
        public async Task<IActionResult> Index()
        {
            var pendingClaims = await _context.Claims
                .Where(c => c.Status == ClaimStatus.Pending)
                .ToListAsync();
            return View(pendingClaims);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
            {
                return NotFound(); // or return an error message
            }

            try
            {
                claim.Status = ClaimStatus.Approved;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
            {
                return NotFound(); // or return an error message
            }

            try
            {
                claim.Status = ClaimStatus.Rejected;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}