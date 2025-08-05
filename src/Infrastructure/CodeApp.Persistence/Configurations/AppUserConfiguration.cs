using CodeApp.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeApp.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Avatar
            builder.HasOne(b => b.Avatar)
                .WithMany(b => b.AppUsers)
                .HasForeignKey(b => b.AvatarId)
                .IsRequired(false);
        }
    }
}
