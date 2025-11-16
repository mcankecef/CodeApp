namespace CodeApp.Application.Abstractions
{
    public interface IStreakService
    {
        Task UpdateStreakAsync(string userId);
        Task CheckDailyStreaksAsync();
        Task<bool> CheckMilestoneAsync(string userId, int currentStreak);
    }
}