using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.API.Controllers
{
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
            return Ok(_movieService.GetById(id));
        }

        [HttpGet("GetByGenre/{genre}")]
        public IActionResult GetMovieByGenre([FromRoute] int genre)
        {
            return Ok(_movieService.GetByGenre(genre));
        }

        [HttpPost("Create")]
        public IActionResult CreateMovie([FromBody] MovieModel model)
        {
            _movieService.Create(model);
            return Ok();
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            _movieService.Delete(id);
            return Ok();
        }
    }
}
