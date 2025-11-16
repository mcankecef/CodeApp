using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Exceptions;
using CodeApp.Application.Repositories.UserStreak;
using CodeApp.Application.Token;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CodeApp.Application.Features.AuthCommandQuery.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, BaseResponse<TokenDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IUserStreakReadRepository _userStreakReadRepository;

        public LoginUserCommandHandler(
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            ITokenHandler tokenHandler, 
            IHttpContextAccessor httpContextAccessor, 
            IUserService userService,
            IUserStreakReadRepository userStreakReadRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _userStreakReadRepository = userStreakReadRepository;
        }

        public async Task<BaseResponse<TokenDto>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var userQuery = _userManager.Users
                .Include(u => u.Avatar).AsQueryable();

            var user = await userQuery
                .FirstOrDefaultAsync(u => u.UserName == request.UsernameOrEmail);

            user ??= await userQuery
                .FirstOrDefaultAsync(u => u.Email == request.UsernameOrEmail);

            if (user is null)
                throw new UserLoginFailedException("Username or password incorrect!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.FullName),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                };
                var token = _tokenHandler.CreateAccessToken(7, authClaims);

                token.UserId = user.Id;
                token.ImageUrl = user?.Avatar?.ImageUrl ?? string.Empty;
                token.Score = user.Score;
                token.UserName = user.UserName ?? string.Empty;
                token.Email = user.Email ?? string.Empty;
                token.FullName = user.FullName;
                
                // Streak Information
                var userStreak = await _userStreakReadRepository.GetByFilterAsync(x => x.UserId == user.Id);
                token.CurrentStreak = userStreak?.CurrentStreak ?? 0;
                token.LongestStreak = userStreak?.LongestStreak ?? 0;

                var refreshTokenLifeTime = token.Expiration.AddHours(1);

                await _userService.UpdateRefreshToken(user, token.RefreshToken, refreshTokenLifeTime);

                return new BaseResponse<TokenDto>("Succesfully logged into the application", true, token);
            }

            return new BaseResponse<TokenDto>("Failed logged into the application", false);
        }

    }
}
