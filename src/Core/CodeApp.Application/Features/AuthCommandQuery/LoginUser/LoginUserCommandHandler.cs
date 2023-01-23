﻿using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Exceptions;
using CodeApp.Application.Token;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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


        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse<TokenDto>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

            user ??= await _userManager.FindByEmailAsync(request.UsernameOrEmail);

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
                var token = _tokenHandler.CreateAccessToken(5, authClaims);
                token.UserId = user.Id;

                return new BaseResponse<TokenDto>("Succesfully logged into the application", true, token);
            }

            return new BaseResponse<TokenDto>("Failed logged into the application", false);
        }

    }
}
