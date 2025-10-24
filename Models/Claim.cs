namespace cmcs_poe_part1.Models
{
    public class Claim
    {
     
            public int Id { get; set; }
            public string NameSurname { get; set; }
            public string Faculty { get; set; }
            public string Role { get; set; }
            public DateTime Date { get; set; }
            public int HoursWorked { get; set; }
            public int HourlyRate { get; set; }
            public string SupportingDocuments { get; set; }
            public double Amount { get; set; }
        }
    }

