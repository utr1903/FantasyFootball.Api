using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UsersService.Authenticator.Models;
using FantasyFootball.Service.PrimitiveServices.UsersService;
using LinqKit;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FantasyFootball.Service.AdvancedServices.UsersService.Authenticator
{
    public class Authenticator
    {
        private IUsersServiceP _usersServiceP;
        private IConfiguration _configuration;

        public Authenticator(
            
            // Primitive Services
            IUsersServiceP usersServiceP,
            
            // Config
            IConfiguration configuration)
        {
            // Primitive Services
            _usersServiceP = usersServiceP;

            // Config
            _configuration = configuration;
        }

        public AuthenticationResultModel AuthenticateUser(User loginCredentials)
        {
            var user = FindUser(loginCredentials);
            if (user == null)
                throw new Exception("UserNotFound");

            var tokenString = GenerateJWTToken(user);

            var result = new AuthenticationResultModel
            {
                User = user,
                TokenString = tokenString
            };

            return result;
        }

        private User FindUser(User loginCredentials)
        {
            var predicateUser = PredicateBuilder.New<User>(true);
            predicateUser = predicateUser.And(x => x.Username == loginCredentials.Username);
            predicateUser = predicateUser.And(x => x.Password == loginCredentials.Password);

            var user = _usersServiceP.Queryable().Where(predicateUser).FirstOrDefault();
            return user;
        }

        private string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                //new Claim("fullName", user.FullName.ToString()),
                //new Claim("role", user.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
