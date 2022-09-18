using MoviesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct.Users;

namespace MoviesApp.DAL.Repositories
{
    public class MovieEntityRepository : IRepository<MovieDto>
    {
        private readonly MoviesAppDbContext _dbContext;

        public MovieEntityRepository(MoviesAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(MovieDto entity)
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

        public MovieDto GetById(int id, int userId)
        {
            return _dbContext.Movies.SingleOrDefault(m => m.Id == id && m.UserId == userId);
        }

        public MovieDto GetById(int id)
        {
            return _dbContext.Movies.SingleOrDefault(m => m.Id == id);
        }
    }
}
