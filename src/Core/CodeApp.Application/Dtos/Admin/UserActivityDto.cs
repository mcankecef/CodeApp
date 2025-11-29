namespace CodeApp.Application.Dtos.Admin
{
    public class UserActivityDto
    {
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ActivityType { get; set; } = string.Empty;
        public string ActivityDescription { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; }
        public int Score { get; set; }
    }
}