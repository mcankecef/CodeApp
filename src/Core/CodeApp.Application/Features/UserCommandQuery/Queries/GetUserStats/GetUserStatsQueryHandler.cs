using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetUserStats;

public class GetUserStatsQueryHandler : IRequestHandler<GetUserStatsQueryRequest, BaseResponse<UserStatsDto>>
{
    private readonly UserManager<AppUser> _userManager;

    public GetUserStatsQueryHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<BaseResponse<UserStatsDto>> Handle(GetUserStatsQueryRequest request, CancellationToken cancellationToken)
    {
        var stats = new UserStatsDto
        {
            TotalUsers = await _userManager.Users.CountAsync(cancellationToken)
        };

        var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);
        stats.ActiveUsers = await _userManager.Users
            .Include(u => u.Streak)
            .Where(u => u.Streak != null && u.Streak.LastActivityDate >= sevenDaysAgo)
            .CountAsync(cancellationToken);

        var today = DateTime.UtcNow.Date;
        var tomorrow = today.AddDays(1);

        stats.NewUsersToday = await _userManager.Users
            .Where(u => u.CreatedDate >= today && u.CreatedDate < tomorrow)
            .CountAsync(cancellationToken);

        stats.ActiveUsersToday = await _userManager.Users
            .Include(u => u.Streak)
            .Where(u => u.Streak != null && 
                       u.Streak.LastActivityDate != null && 
                       u.Streak.LastActivityDate.Value.Date == today)
            .CountAsync(cancellationToken);

        return new BaseResponse<UserStatsDto>("User statistics retrieved successfully", true, stats);
    }
}
