using cmcs_poe_part1.Models;

namespace cmcs_poe_part1.Services
{
    public class ClaimVerificationService
    {
        public async Task<bool> VerifyClaim( claim)
        {
            // Check hours worked
            if (claim.HoursWorked > 40)
            {
                return false;
            }

            // Check hourly rate
            if (claim.HourlyRate > 50)
            {
                return false;
            }

            // Check relevant policies
            // ...

            return true;
        }

        internal async Task<bool> VerifyClaim(LectureClaims claim)
        {
            throw new NotImplementedException();
        }
    }
}