using CodeApp.Domain.Entities.Identity;
using CodeApp.Domain.Enums;

namespace CodeApp.Domain.Entities
{
    public class Avatar : BaseEntity
    {
        public Avatar() => AppUsers = new List<AppUser>();
        public string ImageUrl { get; set; }
        public string? Description { get; set; }
        public StatusType Status { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
