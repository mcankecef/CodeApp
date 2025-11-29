using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Exceptions;
using CodeApp.Application.Token;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CodeApp.Application.Features.AuthCommandQuery.RefreshToken
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, BaseResponse<TokenDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public RefreshTokenLoginCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<BaseResponse<TokenDto>> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
                .Include(u => u.Avatar)
                .FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);

            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                
                var token = _tokenHandler.CreateAccessToken(7, authClaims, false);

                token.UserId = user.Id;
                token.ImageUrl = user.Avatar?.ImageUrl ?? string.Empty;
                token.Score = user.Score;
                token.UserName = user.UserName ?? string.Empty;
                token.Email = user.Email ?? string.Empty;
                token.FullName = user.FullName;
                token.Role = userRoles.FirstOrDefault() ?? string.Empty;

                var accessTokenLifeTime = token.Expiration.AddHours(1);

                await _userService.UpdateRefreshToken(user, token.RefreshToken, accessTokenLifeTime);

                return new BaseResponse<TokenDto>(token);
            }
            throw new UserNotFoundException();
        }
    }
}
