using CodeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeApp.Persistence.Configurations
{
    public class UserStreakConfiguration : IEntityTypeConfiguration<UserStreak>
    {
        public void Configure(EntityTypeBuilder<UserStreak> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(450);
                
            builder.Property(x => x.CurrentStreak)
                .HasDefaultValue(0);
                
            builder.Property(x => x.LongestStreak)
                .HasDefaultValue(0);
                
            builder.HasOne(x => x.User)
                .WithOne(x => x.Streak)
                .HasForeignKey<UserStreak>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasIndex(x => x.UserId)
                .IsUnique();
        }
    }
}