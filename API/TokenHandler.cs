using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace API
{
    public class TokenHandler
    {
        private readonly JwtSecurityTokenHandler tokenHandler = new();
        private readonly IConfiguration config;

        public TokenHandler(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerateJWTToken(string userID)
        {
            var tokenKey = Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userID)
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
