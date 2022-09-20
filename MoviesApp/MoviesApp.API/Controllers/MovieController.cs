using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using MoviesApp.Services.Interfaces;
using System.Security.Claims;

namespace MoviesApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllMovies()
        {
            return Ok(_movieService.GetAll());
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetMovieById([FromRoute] int id)
        {
            var userId = GetAuthorisedUserId();
            var response = _movieService.GetById(id, userId);
            return Ok(response);
        }

        [HttpGet("GetByGenre/{genre}")]
        public IActionResult GetMovieByGenre([FromRoute] int genre)
        {
            var UserId = GetAuthorisedUserId();
            var response = _movieService.GetByGenre(genre);
            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateMovie([FromBody] MovieModel model)
        {
            model.UserId = GetAuthorisedUserId();
            _movieService.Create(model);
            return Ok();
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            _movieService.Delete(id);
            return Ok();
        }

        private int GetAuthorisedUserId()
        {
            if(!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                string name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new Exception("Something went wrong");
            }
            return userId;
        }
    }
}
