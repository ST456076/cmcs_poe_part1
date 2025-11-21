using System.ComponentModel.DataAnnotations;

namespace cmcs_poe_part1.Models
{
    public class LectureClaims
    {
        [Key]
        public int Id { get; set; }

        public int LecturerId { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }
        public double Amount { get; set; }
      

        public ClaimStatus Status { get; set; } // Add this property to 
        // Add other properties as needed
    }
}