using Backend.Models.Entity;
using Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly JwtService _jwtService;
        private readonly UserService _userService;
        public UserController(JwtService jwtService, UserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            var UserEmail = _userService.ValidateUser(req.Email, req.Password);
            if (UserEmail == null) return Unauthorized();

            var token = _jwtService.GenerateToken(UserEmail.ToString());

            return Ok(new { token });
        }

        [HttpPost("addNewUser")]
        public ActionResult<bool> AddNewUser([FromBody] EpUser userData)
        {
            var result = _userService.AddNewUser(userData);

            if (result)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(500, false);
            }
        }

        [Authorize]
        [HttpGet("userData")]
        public IActionResult GetUserData()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok($"{userId}");
        }
    }
}
