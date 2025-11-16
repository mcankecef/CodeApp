namespace CodeApp.Application.Dtos.User;
public class GetUserByIdDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Score { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public Guid AvatarId { get; set; }
}
