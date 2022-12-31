using CodeApp.Application.Dtos;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.AddScoreToUser
{
    public class UpdateScoreToUserCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public string UserId { get; set; }
        public int Score { get; set; }
    }
}
