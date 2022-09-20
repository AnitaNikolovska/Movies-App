using Microsoft.EntityFrameworkCore;
using MoviesApp.DataModels;
using MoviesApp.Helpers;
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

        public DbSet<UserDto> Users { get; set; }
        public DbSet<MovieDto> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDto>()
                .HasOne(n => n.User)
                .WithMany(u => u.MovieList)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<UserDto>()
                        .HasData(
                            new UserDto
                            {
                                Id = 1,
                                FirstName = "Bob",
                                LastName = "Bobsky",
                                Username = "bbob",
                                Password = StringHasher.HashGenerator("P@ssw0rd")
                            });
            
            modelBuilder.Entity<MovieDto>()
                .HasData(
                    new MovieDto
                    {
                        Id = 1,
                        Title = "Titanic",
                        Description = "Movie about a ship",
                        Year = 1997,
                        Genre = 6,
                        UserId = 1
                    },
                    new MovieDto 
                    { 
                        Id = 2,
                        Title = "Spiderman",
                        Description = "Boy gets bitten by spider, gets superpowers",
                        Year = 2002,
                        Genre = 4,
                        UserId = 1
                    }
                );
        }
    }
}
