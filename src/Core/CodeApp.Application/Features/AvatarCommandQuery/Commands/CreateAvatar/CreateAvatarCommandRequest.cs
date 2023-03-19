using CodeApp.Application.Dtos.Avatar;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AvatarCommandQuery.Commands.CreateAvatar
{
    public class CreateAvatarCommandRequest : IRequest<BaseResponse<CreateAvatarDto>>
    {
        public string ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}
