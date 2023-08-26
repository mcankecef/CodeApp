using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Exceptions;
using CodeApp.Application.Token;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);

            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                var token = _tokenHandler.CreateAccessToken(7, null);

                var accessTokenLifeTime = token.Expiration.AddHours(1);

                await _userService.UpdateRefreshToken(user, token.RefreshToken, accessTokenLifeTime);

                return new BaseResponse<TokenDto>(token);
            }
            throw new UserNotFoundException();
        }
    }
}
