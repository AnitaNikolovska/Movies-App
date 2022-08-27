using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieModel> GetAll();
        MovieModel GetById(int id);
        MovieModel GetByGenre(int genre);
        void Create(MovieModel model);
        void Delete(int id);
    }
}
