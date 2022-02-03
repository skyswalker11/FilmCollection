using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This page provides seeding for the database tables
namespace FilmCollection.Models
{
    public class FilmContext : DbContext
    {
        //Constructor
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<ApplicationResponse> R { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                
                    new Category { CategoryID=1, CategoryName="Action/Adventure"},
                    new Category { CategoryID=2, CategoryName="Comedy"},
                    new Category { CategoryID = 3, CategoryName = "Drama" },
                    new Category { CategoryID = 4, CategoryName = "Family" },
                    new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                    new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                    new Category { CategoryID = 7, CategoryName = "Television" },
                    new Category { CategoryID = 8, CategoryName = "VHS" }
                );

            mb.Entity<ApplicationResponse>().HasData(
               
                new ApplicationResponse
                {
                    ApplicationID = 1,
                    CategoryID = 4,
                    Title = "Lilo and Stitch",
                    Year = 2002,
                    Director = "Chris Sanders",
                    Rating = "G",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },

                new ApplicationResponse
                {
                    ApplicationID = 2,
                    CategoryID = 4,
                    Title = "Mulan",
                    Year = 1998,
                    Director = "Tony Bancroft",
                    Rating = "G",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    ApplicationID = 3,
                    CategoryID = 4,
                    Title = "Aladdin",
                    Year = 2002,
                    Director = "Ron Clements",
                    Rating = "G",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
              );
        }
    }
}
