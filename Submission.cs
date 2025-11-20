public class Submission
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Add this property to fix CS1061
    public string Faculty { get; set; }
    public DateTime Date { get; set; }
    public int HoursWorked { get; set; }
    public string Status { get; set; }
}
