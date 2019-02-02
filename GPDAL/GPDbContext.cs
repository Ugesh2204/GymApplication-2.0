using GPBOL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace GPDAL
{
    public class GPDbContext: IdentityDbContext
    {
        public GPDbContext(DbContextOptions<GPDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-7BGFQJH;Database=GYMPRONEW;Trusted_Connection=True;");
        //}

        public DbSet<Goal> Goals { get; set; }
        public DbSet<GPWorkout> GPWorkouts { get; set; }
      
    }
}

