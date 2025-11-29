using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.BanUser
{
    public class BanUserCommandHandler : IRequestHandler<BanUserCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly UserManager<AppUser> _userManager;

        public BanUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(BanUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return new BaseResponse<NoContentDto>("User not found", false, new NoContentDto());
            }

            user.IsActive = false;
            var result = await _userManager.UpdateAsync(user);
            
            if (!result.Succeeded)
            {
                return new BaseResponse<NoContentDto>("Failed to ban user", false, new NoContentDto());
            }

            return new BaseResponse<NoContentDto>(
                $"User {user.FullName} has been banned. Reason: {request.Reason}",
                true,
                new NoContentDto());
        }
    }
}