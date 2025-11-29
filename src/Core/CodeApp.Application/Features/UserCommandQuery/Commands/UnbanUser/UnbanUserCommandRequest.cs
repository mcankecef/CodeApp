using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UnbanUser
{
    public class UnbanUserCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public string UserId { get; set; } = string.Empty;
    }
}