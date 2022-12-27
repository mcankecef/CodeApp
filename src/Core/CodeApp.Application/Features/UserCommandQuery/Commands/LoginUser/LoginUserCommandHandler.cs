using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Exceptions;
using CodeApp.Application.Token;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, BaseResponse<TokenDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<BaseResponse<TokenDto>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

            if (user is null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (user is null)
                throw new UserLoginFailedException("Username or password incorrect!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                var token = _tokenHandler.CreateAccessToken(5);

                return new BaseResponse<TokenDto>("Succesfully logged into the application",true,token);
            }

            return new BaseResponse<TokenDto>("Failed logged into the application", false);
        }

    }
}
