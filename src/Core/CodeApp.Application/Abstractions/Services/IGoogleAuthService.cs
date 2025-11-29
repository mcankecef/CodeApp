using CodeApp.Application.Dtos.Auth;

namespace CodeApp.Application.Abstractions.Services
{
    public interface IGoogleAuthService
    {
        Task<GoogleUserInfoDto?> ValidateGoogleTokenAsync(string idToken);
    }
}
