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
    }
}
