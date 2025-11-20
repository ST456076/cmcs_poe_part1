using System.ComponentModel.DataAnnotations;

namespace cmcs_poe_part1.Models
{
    public class Lecturer
    {
        [Key]
        public int Id { get; set; }

        public int LecturerId { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        // Add other properties as needed
    }
}