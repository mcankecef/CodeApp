using CodeApp.Application.Abstractions;
using CodeApp.Application.Dtos.User;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUserAvatar
{
    public class UpdateUserAvatarCommandHandler : IRequestHandler<UpdateUserAvatarCommandRequest, BaseResponse<string>>
    {
        private readonly IUserService _userService;

        public UpdateUserAvatarCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseResponse<string>> Handle(UpdateUserAvatarCommandRequest request, CancellationToken cancellationToken)
        {

            var avatarImage = await _userService.UpdateUserAvatar(new UpdateUserAvatarDto
            {
                AvatarId = request.AvatarId,
                UserId = request.UserId
            });

            return new BaseResponse<string>(avatarImage);
        }
    }
}
