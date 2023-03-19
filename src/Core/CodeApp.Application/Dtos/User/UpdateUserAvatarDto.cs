namespace CodeApp.Application.Dtos.User
{
    public class UpdateUserAvatarDto
    {
        public string UserId { get; set; }
        public Guid AvatarId { get; set; }
    }
}
