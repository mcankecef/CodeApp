using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.LoginUser
{
    public class LoginUserCommandRequest : IRequest<BaseResponse<TokenDto>>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
