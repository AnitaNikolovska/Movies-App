using MoviesApp.DAL;
using MoviesApp.DataModels;
using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using MoviesApp.Mappers;
using MoviesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<MovieDto> _movieRepository;
        public MovieService(IRepository<MovieDto> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieModel> GetAll()
        {
            return _movieRepository.GetAll()
                    .Select(m => MovieMapper.ToMovieModel(m))
                    .ToList();
        }

        public MovieModel GetById(int id)
        {
            return MovieMapper.ToMovieModel(_movieRepository.GetById(id));
        }
        public MovieModel GetByGenre(int genre)
        {
            return MovieMapper.ToMovieModel(_movieRepository.GetByGenre(genre));
        }

        public void Create(MovieModel model)
        {
            _movieRepository.AddMovie(MovieMapper.ToMovieDto(model));
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(_movieRepository.GetById(id));
        }
    }
}
