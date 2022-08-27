using MoviesApp.DataModels;
using MoviesApp.InterfaceModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL
{
    public static class StaticDb
    {
        public static int MoviesIdCounter = 0;
        public static List<MovieDto> Movies = new List<MovieDto>()
        {
            new MovieDto
            {
                Id = 0,
                Title = "Titanic",
                Description = "Movie about a ship",
                Year = 1997,
                Genre = 6
            }
        };
    }
}
