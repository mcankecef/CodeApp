using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.BanUser
{
    public class BanUserCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public string UserId { get; set; } = string.Empty;
        public int BanDurationDays { get; set; } = 30;
        public string Reason { get; set; } = string.Empty;
    }
}