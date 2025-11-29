using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandRequest, BaseResponse<NoContentDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UpdateUserRoleCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<BaseResponse<NoContentDto>> Handle(UpdateUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return new BaseResponse<NoContentDto>("User not found", false, new NoContentDto());
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
            }

            var validRoles = new List<string>();
            foreach (var roleName in request.Roles)
            {
                if (await _roleManager.RoleExistsAsync(roleName))
                {
                    validRoles.Add(roleName);
                }
            }

            if (validRoles.Any())
            {
                await _userManager.AddToRolesAsync(user, validRoles);
            }

            return new BaseResponse<NoContentDto>(
                $"User {user.FullName} roles updated successfully",
                true,
                new NoContentDto());
        }
    }
}