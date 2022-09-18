using MoviesApp.DataModels;
using MoviesApp.InterfaceModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL.Repositories
{
    public class MovieStaticDbRepository : IRepository<MovieDto>
    {
        public void Add(MovieDto entity)
        {
            entity.Id = ++StaticDb.MoviesIdCounter;
            StaticDb.Movies.Add(entity);
        }

        public void Delete(MovieDto entity)
        {
            StaticDb.Movies.Remove(entity);
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return StaticDb.Movies;
        }

        public MovieDto GetByGenre(int genre)
        {
            return StaticDb.Movies.FirstOrDefault(m => m.Genre == genre);
        }

        public MovieDto GetById(int id, int userId)
        {
            return StaticDb.Movies.FirstOrDefault(m => m.Id == id);
        }

        public MovieDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
