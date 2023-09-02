namespace CodeApp.Application.Dtos.User
{
    public class UpdateUserDto
    {
        public string UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public Guid? AvatarId { get; set; }
    }
}
