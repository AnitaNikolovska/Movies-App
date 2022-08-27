using MoviesApp.DataModels;
using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToMovieDto(MovieModel model)
        {
            return new MovieDto
            {
                Title = model.Title,
                Description = model.Description,
                Year = model.Year,
                Genre = (int)model.Genre
            };
        }

        public static MovieModel ToMovieModel(MovieDto model)
        {
            return new MovieModel
            {
                Title = model.Title,
                Description = model.Description,
                Year = model.Year,
                Genre = (GenreEnum)model.Genre
            };
        }
    }
}
