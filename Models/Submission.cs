using System;
using System.ComponentModel.DataAnnotations;

namespace cmcs_poe_part1.Models
{
    public class Submission
    {
        public int Id { get; set; }

        [Required]
        public string NameSurname { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int HoursWorked { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; internal set; } = "Pending";

        public bool PreApproved { get; set; } = false;
        public bool Declined { get; set; } = false;
        public string PreApprovedBy { get; set; }
        public DateTime? PreApprovedDate { get; set; }
        public string DeclinedBy { get; set; }
        public DateTime? DeclinedDate { get; set; }

        public string SupportingDocuments { get; set; }
        public string WouldYouLikeToaddSomething { get; set; }
    }
}

