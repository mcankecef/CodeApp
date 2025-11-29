using CodeApp.Application.Abstractions.Services;
using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Token;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using CodeApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CodeApp.Application.Features.AuthCommandQuery.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, BaseResponse<TokenDto>>
    {
        private readonly IGoogleAuthService _googleAuthService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IConfiguration _configuration;

        public GoogleLoginCommandHandler(
            IGoogleAuthService googleAuthService,
            UserManager<AppUser> userManager,
            ITokenHandler tokenHandler,
            IConfiguration configuration)
        {
            _googleAuthService = googleAuthService;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
        }

        public async Task<BaseResponse<TokenDto>> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var googleUser = await _googleAuthService.ValidateGoogleTokenAsync(request.IdToken);

            if (googleUser == null)
            {
                return new BaseResponse<TokenDto>("Invalid Google token", false, default);
            }

            var user = await _userManager.FindByEmailAsync(googleUser.Email);

            if (user == null)
            {
                var defaultAvatarId = Guid.Parse(_configuration["DefaultAvatarId"] ?? Guid.Empty.ToString());

                user = new AppUser
                {
                    Email = googleUser.Email,
                    UserName = googleUser.Email.Split('@')[0], // Email'in @ öncesi kısmı
                    FullName = googleUser.Name,
                    EmailConfirmed = true, // Google'dan geldiği için email doğrulanmış sayılır
                    AvatarId = defaultAvatarId,
                    Score = 0,
                    CreatedDate = DateTime.UtcNow
                };

                var createResult = await _userManager.CreateAsync(user);

                if (!createResult.Succeeded)
                {
                    return new BaseResponse<TokenDto>("Failed to create user: " + string.Join(", ", createResult.Errors.Select(e => e.Description)), false, default);
                }

                await _userManager.AddToRoleAsync(user, UserRoles.Member.ToString());
            }

            if (await _userManager.IsLockedOutAsync(user))
            {
                return new BaseResponse<TokenDto>("User account is locked", false, default);
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = _tokenHandler.CreateAccessToken(1, authClaims, request.RememberMe);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddMinutes(
                int.Parse(_configuration["Token:RefreshTokenExpiration"] ?? "1440"));
            user.LastLoggedSession = DateTime.UtcNow;
            
            await _userManager.UpdateAsync(user);

            return new BaseResponse<TokenDto>("Google login successful", true, token);
        }
    }
}
