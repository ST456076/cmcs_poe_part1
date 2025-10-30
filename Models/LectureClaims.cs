namespace cmcs_poe_part1.Models
{
    public class LectureClaims
    {
            public int Id { get; set; }
            public required string NameSurname { get; set; }
            public required string Faculty { get; set; }
            public DateTime Date { get; set; }
            public int HoursWorked { get; set; }
            public int HourlyRate { get; set; }
            public string SupportingDocuments { get; set; }
            public double Amount { get; set; }
            public string WouldYouLikeToaddSomething { get; set; }

            public string Status { get; set; } // Add this property to 
    }



}

