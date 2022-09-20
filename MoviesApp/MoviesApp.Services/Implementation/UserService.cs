using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoviesApp.Configuration;
using MoviesApp.DAL;
using MoviesApp.DataModels;
using MoviesApp.Helpers;
using MoviesApp.InterfaceModels.Models;
using MoviesApp.Mappers;
using MoviesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoviesApp.Services.Implementation
{
    //System.IdentityModel.Tokens.Jwt
    public class UserService : IUserService
    {
        private readonly IRepository<UserDto> _userRepository;
        private readonly AppSettings _appSettings;

        public UserService(IRepository<UserDto> userRepository, 
                           IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public UserModel Authenticate(string username, string password)
        {
            var hashedPassword = StringHasher.HashGenerator(password);
            var user = _userRepository.GetAll().SingleOrDefault(u =>
                       u.Username == username && u.Password == hashedPassword);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }
                ),
                //Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)
            };
        }

        public void Register(RegisterModel model)
        {
            var hashedPassword = StringHasher.HashGenerator(model.Password);

            var user = new UserDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password
            };

            _userRepository.Add(user);
        }

        public List<UserModel> GetUsers()
        {
            return _userRepository.GetAll()
                                  .Select(u => UserMapper.ToUserModel(u))
                                  .ToList();
        }

        public bool ValidateUsername(string username)
        {
            return _userRepository.GetAll()
                                  .Any(u => u.Username == username);
        }

        public bool ValidatePassword(string password)
        {
            var passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            var match = passwordRegex.Match(password);
            return match.Success;
        }
    }
}
