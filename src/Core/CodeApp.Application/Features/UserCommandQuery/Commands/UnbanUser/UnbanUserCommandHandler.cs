using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UnbanUser
{
    public class UnbanUserCommandHandler : IRequestHandler<UnbanUserCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly UserManager<AppUser> _userManager;

        public UnbanUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UnbanUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return new BaseResponse<NoContentDto>("User not found", false, new NoContentDto());
            }

            user.IsActive = true;
            var result = await _userManager.UpdateAsync(user);
            
            if (!result.Succeeded)
            {
                return new BaseResponse<NoContentDto>("Failed to unban user", false, new NoContentDto());
            }

            return new BaseResponse<NoContentDto>(
                $"User {user.FullName} has been unbanned successfully",
                true,
                new NoContentDto());
        }
    }
}