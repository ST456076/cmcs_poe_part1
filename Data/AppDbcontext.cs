using System;
using cmcs_poe_part1.Controllers;
using cmcs_poe_part1.Models;
using Microsoft.EntityFrameworkCore;

namespace cmcs_poe_part1.Data
{
    public class AppDbcontext : DbContext
    {

        public AppDbcontext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<login_Infos> Login_Infos { get; set; }
        public DbSet<Claim> Claims { get; set; }

    }

    public class login_Infos
    {
    }
}