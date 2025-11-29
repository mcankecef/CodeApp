using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AuthCommandQuery.GoogleLogin
{
    public class GoogleLoginCommandRequest : IRequest<BaseResponse<TokenDto>>
    {
        public string IdToken { get; set; } = string.Empty;
        public bool RememberMe { get; set; } = false;
    }
}
