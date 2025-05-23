using Backend.Service;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

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
            var user = _userService.ValidateUser(req.Email, req.Password);
            if (user == null) return Unauthorized();

            var token = _jwtService.GenerateToken(user.UserEmail.ToString());

            return Ok(new { token });
        }
    }
}
