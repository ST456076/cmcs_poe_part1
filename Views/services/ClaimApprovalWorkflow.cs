using cmcs_poe_part1.Models;
using System.Threading.Tasks;

namespace cmcs_poe_part1.Services
{
    public class ClaimApprovalWorkflow
    {
        public async Task ApproveClaim(LectureClaims claim)
        {
            // Approve claim logic
        }

        public async Task RejectClaim(LectureClaims claim)
        {
            // Reject claim logic
        }

        public async Task<Invoice> GenerateInvoice(LectureClaims claim)
        {
            // Calculate claim amount
            var claimAmount = claim.HoursWorked * claim.HourlyRate;

            // Create invoice
            var invoice = new Invoice
            {
                ClaimId = claim.Id,
                Amount = claimAmount,
                // Other invoice properties
            };

            return invoice;
        }
    }
}