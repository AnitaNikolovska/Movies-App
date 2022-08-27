using MoviesApp.InterfaceModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetByGenre(int genre);
        void AddMovie(T entity);
        void Delete(T entity);
    }
}
