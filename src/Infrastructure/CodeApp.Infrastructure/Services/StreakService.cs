using CodeApp.Application.Abstractions;
using CodeApp.Application.Repositories.UserStreak;
using CodeApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Infrastructure.Services
{
    public class StreakService : IStreakService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStreakReadRepository _userStreakReadRepository;
        private readonly IUserStreakWriteRepository _userStreakWriteRepository;

        public StreakService(
            UserManager<AppUser> userManager,
            IUserStreakReadRepository userStreakReadRepository,
            IUserStreakWriteRepository userStreakWriteRepository)
        {
            _userManager = userManager;
            _userStreakReadRepository = userStreakReadRepository;
            _userStreakWriteRepository = userStreakWriteRepository;
        }

        public async Task UpdateStreakAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return;

            var today = DateTime.Today;
            var yesterday = today.AddDays(-1);

            var userStreak = await _userStreakReadRepository.GetByFilterAsync(x => x.UserId == userId);
            if (userStreak == null)
            {
                userStreak = new Domain.Entities.UserStreak
                {
                    UserId = userId,
                    CurrentStreak = 0,
                    LongestStreak = 0,
                    LastActivityDate = null,
                    StreakStartDate = null
                };
                await _userStreakWriteRepository.CreateAsync(userStreak);
            }

            if (userStreak.LastActivityDate?.Date == today)
                return;

            UpdateCurrentStreak(today, yesterday, userStreak);

            if (userStreak.CurrentStreak > userStreak.LongestStreak)
                userStreak.LongestStreak = userStreak.CurrentStreak;

            userStreak.LastActivityDate = DateTime.Now;
            _userStreakWriteRepository.Update(userStreak);

            await CheckMilestoneAsync(userId, userStreak.CurrentStreak);
        }

        private static void UpdateCurrentStreak(DateTime today, DateTime yesterday, Domain.Entities.UserStreak userStreak)
        {
            if (userStreak.LastActivityDate?.Date == yesterday)
            {
                userStreak.CurrentStreak++;
            }
            else if (userStreak.LastActivityDate?.Date < yesterday)
            {
                userStreak.CurrentStreak = 1;
                userStreak.StreakStartDate = today;
            }
            else
            {
                userStreak.CurrentStreak = 1;
                userStreak.StreakStartDate = today;
            }
        }

        public async Task CheckDailyStreaksAsync()
        {
            var yesterday = DateTime.Today.AddDays(-1);
            
            var brokenStreaks = await _userStreakReadRepository.Queryable()
                .Where(u => u.CurrentStreak > 0 && 
                           (u.LastActivityDate == null || u.LastActivityDate.Value.Date < yesterday))
                .ToListAsync();

            foreach (var streak in brokenStreaks)
            {
                streak.CurrentStreak = 0;
                streak.StreakStartDate = null;
                _userStreakWriteRepository.Update(streak);
            }
        }

        public async Task<bool> CheckMilestoneAsync(string userId, int currentStreak)
        {
            var milestones = new int[] { 3, 7, 14, 30, 100, 365 };
            
            if (milestones.Contains(currentStreak))
            {
                return true;
            }

            return false;
        }
    }
}