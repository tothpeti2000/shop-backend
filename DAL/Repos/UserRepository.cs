using DAL.DbObjects;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<DbUser> userManager;
        private readonly IConfiguration config;

        public UserRepository(UserManager<DbUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }

        public async Task<AsyncResult> CreateUserAsync(User user)
        {
            var newUser = new DbUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var result = await userManager.CreateAsync(newUser, user.Password);
            var errorMessages = result.Errors
                .Select(err => err.Description)
                .ToList();

            return new AsyncResult
            {
                Succeeded = result.Succeeded,
                ErrorMessages = errorMessages
            };
        }

        public async Task<AsyncResult> LoginUserAsync(LoginCredentials data)
        {
            var user = await userManager.FindByNameAsync(data.UserName);

            if (user == null)
            {
                return new AsyncResult
                {
                    Succeeded = false,
                    ErrorMessages = new List<string> { "Sorry, we couldn't find a user with the given username." }
                };
            }

            var passwordOK = await userManager.CheckPasswordAsync(user, data.Password);

            if (!passwordOK)
            {
                return new AsyncResult
                {
                    Succeeded = false,
                    ErrorMessages = new List<string> { "Wrong password! Please, try again!" }
                };
            }

            return new AsyncResult
            {
                Succeeded = true,
                Token = GenerateJWTToken(user)
            };
        }

        private string GenerateJWTToken(DbUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Issuer = config.GetSection("JWT:Issuer").Value,
                Audience = config.GetSection("JWT:Audience").Value,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
