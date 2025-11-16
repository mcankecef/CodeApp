using CodeApp.Application.Dtos.Streak;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.Queries.Streak.GetUserStreak
{
    public class GetUserStreakQuery : IRequest<BaseResponse<UserStreakDto>>
    {
        public string UserId { get; set; }

        public GetUserStreakQuery(string userId)
        {
            UserId = userId;
        }
    }
}