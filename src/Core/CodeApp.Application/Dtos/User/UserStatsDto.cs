namespace CodeApp.Application.Dtos.User;

public class UserStatsDto
{
    public int TotalUsers { get; set; }
    public int ActiveUsers { get; set; }
    public int NewUsersToday { get; set; }
    public int ActiveUsersToday { get; set; }
}
