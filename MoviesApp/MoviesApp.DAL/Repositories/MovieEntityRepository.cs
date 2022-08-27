using MoviesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL.Repositories
{
    public class MovieEntityRepository : IRepository<MovieDto>
    {
        private readonly MoviesAppDbContext _dbContext;

        public MovieEntityRepository(MoviesAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMovie(MovieDto entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(MovieDto entity)
        {
            _dbContext.Movies.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return _dbContext.Movies;
        }

        public MovieDto GetByGenre(int genre)
        {
            return _dbContext.Movies.SingleOrDefault(m => m.Genre == genre);
        }

        public MovieDto GetById(int id)
        {
            return _dbContext.Movies.SingleOrDefault(m => m.Id == id);
        }
    }
}
