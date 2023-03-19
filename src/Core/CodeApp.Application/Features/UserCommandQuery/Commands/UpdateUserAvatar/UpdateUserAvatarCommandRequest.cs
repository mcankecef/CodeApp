using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUserAvatar
{
    public class UpdateUserAvatarCommandRequest : IRequest<BaseResponse<string>>
    {
        public Guid AvatarId { get; set; }
        public string UserId { get; set; }

        public UpdateUserAvatarCommandRequest(Guid avatarId, string userId)
        {
            AvatarId = avatarId;
            UserId = userId;
        }
    }
}
