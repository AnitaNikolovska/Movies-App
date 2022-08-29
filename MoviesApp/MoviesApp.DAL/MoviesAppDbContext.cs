using Microsoft.EntityFrameworkCore;
using MoviesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL
{
    //Microsoft.EntityFrameworkCore
    //Microsoft.EntityFrameworkCore.Abstractions
    //Microsoft.EntityFrameworkCore.Design
    //Microsoft.EntityFrameworkCore.Relational
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Tools
    public class MoviesAppDbContext : DbContext
    {
        public MoviesAppDbContext(DbContextOptions option)
               : base(option) { }

        public DbSet<MovieDto> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDto>()
                .HasData(
                    new MovieDto
                    {
                        Id = 1,
                        Title = "Titanic",
                        Description = "Movie about a ship",
                        Year = 1997,
                        Genre = 6
                    },
                    new MovieDto 
                    { 
                        Id = 2,
                        Title = "Spiderman",
                        Description = "Boy gets bitten by spider, gets superpowers",
                        Year = 2002,
                        Genre = 4
                    }
                );
        }
    }
}
