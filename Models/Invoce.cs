using System;

namespace cmcs_poe_part1.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public decimal Amount { get; set; }
    

public required string Description { get; set; }
public DateTime Date { get; set; }
    }
}