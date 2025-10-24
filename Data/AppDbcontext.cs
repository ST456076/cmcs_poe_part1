using System;
using cmcs_poe_part1.Models;
using Microsoft.EntityFrameworkCore;

namespace cmcs_poe_part1.Data
{
    public class AppDbcontext: DbContext
    {

        public AppDbcontext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       
        public DbSet<user_login_info> Login_Infos { get; set; }
        public DbSet<Claim> Claims { get; set; } 

        }
    }

