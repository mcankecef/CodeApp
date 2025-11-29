using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AuthCommandQuery.LoginUser
{
    public class LoginUserCommandRequest : IRequest<BaseResponse<TokenDto>>
    {
        public required string UsernameOrEmail { get; set; }
        public required string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
