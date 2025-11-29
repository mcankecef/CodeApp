using CodeApp.Application.Abstractions.Services;
using CodeApp.Application.Dtos.Auth;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;

namespace CodeApp.Infrastructure.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly IConfiguration _configuration;

        public GoogleAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GoogleUserInfoDto?> ValidateGoogleTokenAsync(string idToken)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { _configuration["Google:ClientId"] }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

                if (payload == null)
                    return null;

                return new GoogleUserInfoDto
                {
                    Email = payload.Email,
                    Name = payload.Name,
                    GivenName = payload.GivenName,
                    FamilyName = payload.FamilyName,
                    Picture = payload.Picture,
                    Sub = payload.Subject
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
