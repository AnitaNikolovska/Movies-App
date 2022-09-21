using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.InterfaceModels.Models;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            try
            {
                return Ok(_userService.Authenticate(model.Username, model.Password));
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            try
            {
                _userService.Register(model);
                return Ok("User successfully registered.");
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }
    }
}
