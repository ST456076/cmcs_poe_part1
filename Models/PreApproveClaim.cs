namespace cmcs_poe_part1.Models
{
    public class PreApproveClaim
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Faculty { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public string Status { get; set; }
        public bool? PreApproved { get; set; }
        public string? PreApprovedBy { get; set; }
        public DateTime? PreApprovedDate { get; set; }
        public bool? Declined { get; set; }
        public string? DeclinedBy { get; set; }
        public DateTime? DeclinedDate { get; set; }
    }

}

