using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AppEscolaDeMusica.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Login == dto.Login && u.Senha == dto.Senha);

            if (usuario == null)
                return Unauthorized(new { message = "Login ou senha inválidos" });

            var token = GenerateJwtToken(usuario.Login, usuario.Role.ToString());

            return Ok(new
            {
                Token = token,
                Role = usuario.Role.ToString()
            });
        }

        private string GenerateJwtToken(string login, string role)
        {
            var jwtKey = _configuration["Jwt:Key"] ?? string.Empty;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
