using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeViajes_V2.Controllers
{
    // 1. Define el modelo de usuario
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        // Otras propiedades relevantes
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }


    // 2. Crea el contexto de base de datos
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Otras configuraciones
        }
    }

    // 3. Implementa la autenticación en el controlador
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public LoginController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Genera un token de autenticación
            var token = GenerateToken(user);

            return Ok(new { Token = token });
        }

        private string GenerateToken(User user)
        {
            // Lógica para generar el token JWT

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("TuClaveSecreta"); // Clave secreta para firmar el token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    // Agrega otras claims si es necesario
                }),
                Expires = DateTime.UtcNow.AddDays(7), // Tiempo de expiración del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    // 5. Protege las rutas autenticadas utilizando atributos
    [Authorize]
    public class ProtectedController : ControllerBase
    {
        // Rutas y acciones protegidas
    }
}
