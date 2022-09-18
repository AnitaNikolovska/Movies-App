using MoviesApp.DataModels;
using MoviesApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(UserModel model)
        {
            return new UserDto
            {
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        public static UserModel ToUserModel(UserDto model)
        {
            return new UserModel
            {
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Movies = model.MovieList.Select(m => MovieMapper.ToMovieModel(m)).ToList()
            };
        }
    }
}
