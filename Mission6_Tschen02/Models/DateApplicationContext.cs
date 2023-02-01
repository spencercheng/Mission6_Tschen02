using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission6_Tschen02.Models
{
    public class DateApplicationContext : DbContext
    {
        public DateApplicationContext (DbContextOptions<DateApplicationContext> options) : base(options)
        {

        }
        public DbSet<ApplicationResponse> Responses { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    Category = "Action",
                    Title = "Rush Hour 2",
                    Year = 2001,
                    Director = "Brett Ratner",
                    Rating = "PG-13",
                    Edited = false
                },

                new ApplicationResponse
                {
                    ApplicationId = 2,
                    Category = "Drama",
                    Title = "The other Side of Heaven",
                    Year = 2001,
                    Director = "Mitch Davis",
                    Rating = "PG-13",
                    Edited = true
                },

                new ApplicationResponse
                {
                    ApplicationId = 3,
                    Category = "Action",
                    Title = "Rush Hour 3",
                    Year = 2007,
                    Director = "Brett Ratner",
                    Rating = "PG-13",
                    Edited = false
                }

                );
        }
    }
}
