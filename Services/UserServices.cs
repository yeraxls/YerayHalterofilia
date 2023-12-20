using db;
using db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YerayHalterofilia.Models;

namespace YerayHalterofilia.Services
{
    public class UserServices : IUserServices
    {
        private readonly WeightliftingContext _context;
        private readonly IConfiguration _config;
        public UserServices(WeightliftingContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task CreateUser(UserModel user)
        {
            await _context.Insert<User>((User)user);
            await _context.SaveAll();
        }
        public async Task<User> Authenticate(LoginModel userLogin)
        {
            var currentUser = await _context.Queryable<User>(u => u.UserName == userLogin.UserName
                   && u.Password == userLogin.Password).FirstOrDefaultAsync();

            if (currentUser == null)
                return null;

            return currentUser;
        }

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Crear los claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };


            // Crear el token

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
