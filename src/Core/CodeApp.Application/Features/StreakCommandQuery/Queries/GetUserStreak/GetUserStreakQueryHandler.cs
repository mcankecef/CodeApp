using CodeApp.Application.Dtos.Streak;
using CodeApp.Application.Repositories.UserStreak;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.Queries.Streak.GetUserStreak
{
    public class GetUserStreakQueryHandler : IRequestHandler<GetUserStreakQuery, BaseResponse<UserStreakDto>>
    {
        private readonly IUserStreakReadRepository _userStreakReadRepository;

        public GetUserStreakQueryHandler(IUserStreakReadRepository userStreakReadRepository)
        {
            _userStreakReadRepository = userStreakReadRepository;
        }

        public async Task<BaseResponse<UserStreakDto>> Handle(GetUserStreakQuery request, CancellationToken cancellationToken)
        {
            var userStreak = await _userStreakReadRepository.GetByFilterAsync(x => x.UserId == request.UserId);
            
            if (userStreak == null)
            {
                var emptyStreakDto = new UserStreakDto
                {
                    CurrentStreak = 0,
                    LongestStreak = 0,
                    LastActivityDate = null,
                    StreakStartDate = null
                };
                
                return new BaseResponse<UserStreakDto>("No streak data found", true, emptyStreakDto);
            }

            var streakDto = new UserStreakDto
            {
                CurrentStreak = userStreak.CurrentStreak,
                LongestStreak = userStreak.LongestStreak,
                LastActivityDate = userStreak.LastActivityDate,
                StreakStartDate = userStreak.StreakStartDate
            };

            return new BaseResponse<UserStreakDto>("Streak data retrieved successfully", true, streakDto);
        }
    }
}