using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UpdateScore
{
    public class UpdateScoreCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public string UserId { get; set; }
        public int Score { get; set; }
    }
}
