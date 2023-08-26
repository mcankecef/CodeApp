using CodeApp.Application.Dtos;
using CodeApp.Application.Dtos.Token;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AuthCommandQuery.RefreshToken
{
    public class RefreshTokenLoginCommandRequest : IRequest<BaseResponse<TokenDto>>
    {
        public string RefreshToken { get; set; }

        public RefreshTokenLoginCommandRequest(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
