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
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName="Action/Adventure"},
                new Category { CategoryId=2, CategoryName="Comedy"},
                new Category { CategoryId=3, CategoryName="Drama"},
                new Category { CategoryId=4, CategoryName="Family"},
                new Category { CategoryId=5, CategoryName="Horror/Suspense"},
                new Category { CategoryId=6, CategoryName="Miscellaneous"},
                new Category { CategoryId=7, CategoryName="Television"},
                new Category { CategoryId=8, CategoryName="VHS"}
                );





            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryId = 1,
                    Title = "Rush Hour 2",
                    Year = 2001,
                    Director = "Brett Ratner",
                    Rating = "PG-13",
                    Edited = false
                },

                new ApplicationResponse
                {
                    ApplicationId = 2,
                    CategoryId = 3,
                    Title = "The other Side of Heaven",
                    Year = 2001,
                    Director = "Mitch Davis",
                    Rating = "PG-13",
                    Edited = true
                },

                new ApplicationResponse
                {
                    ApplicationId = 3,
                    CategoryId = 1,
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
