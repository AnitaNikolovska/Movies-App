using Microsoft.EntityFrameworkCore;
using MoviesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL.Repositories
{
    public class UserEntityRepository : IRepository<UserDto>
    {
        private readonly MoviesAppDbContext _dbContext;

        public UserEntityRepository(MoviesAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(UserDto entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(UserDto entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _dbContext.Users.Include(m => m.MovieList);
        }

        public UserDto GetByGenre(int genre)
        {
            throw new NotImplementedException();
        }

        public UserDto GetById(int id)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public UserDto GetById(int id, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
