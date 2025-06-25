using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration; // Make sure this is present

namespace Backend.Service
{
    public class JwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string userId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(JwtRegisteredClaimNames.Sub, userId), // Good practice to include Subject
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Good practice to include JWT ID
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"], // <-- CHANGE THIS LINE HERE
                                                       //audience: _config["JwtSettings:Audience"], // Uncomment if you validate audience
                claims: claims,
                expires: DateTime.Now.AddHours(2), // Consider using UtcNow for consistency
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}