using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetLanguageLeaderboard
{
    public class GetScoreLeaderboardQueryHandler : IRequestHandler<GetScoreLeaderboardQueryRequest, BaseResponse<ScoreLeaderboardResponseDto>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetScoreLeaderboardQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<BaseResponse<ScoreLeaderboardResponseDto>> Handle(GetScoreLeaderboardQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var allUsers = await _userManager.Users.ToListAsync(cancellationToken);
                
                var usersWithScores = allUsers.Select(user => new UserScoreRankDto
                {
                    UserId = Guid.Parse(user.Id),
                    UserName = user.UserName ?? "",
                    FullName = user.FullName,
                    TotalScore = user.Score
                }).ToList();

                var sortedUsers = usersWithScores
                    .OrderByDescending(x => x.TotalScore)
                    .Select((user, index) => 
                    {
                        user.Rank = index + 1;
                        return user;
                    })
                    .ToList();

                var totalUsers = sortedUsers.Count;
                var currentUserRank = sortedUsers
                    .FirstOrDefault(x => x.UserId.ToString() == request.CurrentUserId)?.Rank ?? 0;

                var totalPages = (int)Math.Ceiling((double)totalUsers / request.PageSize);
                var pagedUsers = sortedUsers
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                var response = new ScoreLeaderboardResponseDto
                {
                    Users = pagedUsers,
                    CurrentUserRank = currentUserRank,
                    TotalUsers = totalUsers,
                    CurrentPage = request.Page,
                    TotalPages = totalPages,
                    HasPreviousPage = request.Page > 1,
                    HasNextPage = request.Page < totalPages
                };

                return new BaseResponse<ScoreLeaderboardResponseDto>("Score leaderboard retrieved successfully.", true, response);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ScoreLeaderboardResponseDto>($"An error occurred: {ex.Message}", false, new ScoreLeaderboardResponseDto());
            }
        }
    }
}