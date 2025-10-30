using Microsoft.EntityFrameworkCore;
using cmcs_poe_part1.Models;

namespace cmcs_poe_part1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // This is your database table
        public DbSet<Claim> Claims { get; set; }
        public DbSet<LectureClaims> LectureClaims { get; set; }
        public DbSet<RegisterViewModel> Users { get; set; }
    }
}