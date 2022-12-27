using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateAccessToken(int minute)
        {
            var token = new TokenDto();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            var signinCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddDays(minute);

            var securityToken = new JwtSecurityToken(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signinCredentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
