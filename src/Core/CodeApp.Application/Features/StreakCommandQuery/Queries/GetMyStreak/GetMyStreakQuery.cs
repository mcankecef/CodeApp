using CodeApp.Application.Dtos.Streak;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.Queries.Streak.GetMyStreak
{
    public class GetMyStreakQuery : IRequest<BaseResponse<UserStreakDto>>
    {
        public string UserId { get; set; }

        public GetMyStreakQuery(string userId)
        {
            UserId = userId;
        }
    }
}