using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CodeApp.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenHandler(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public TokenDto CreateAccessToken(int day, List<Claim>? authClaims, bool rememberMe = false)
        {
            var token = new TokenDto();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expirationMinutes = rememberMe 
                ? int.Parse(_configuration["Token:RememberMeTokenExpiration"] ?? "43200")
                : int.Parse(_configuration["Token:AccessTokenExpiration"] ?? "60");

            token.Expiration = DateTime.UtcNow.AddMinutes(expirationMinutes);

            var securityToken = new JwtSecurityToken(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signinCredentials,
                claims: authClaims
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
