namespace CodeApp.Application.Dtos.User;
public class GetUserByIdDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public int Score { get; set; }
    public string ImageUrl { get; set; }
    public Guid AvatarId { get; set; }
}
