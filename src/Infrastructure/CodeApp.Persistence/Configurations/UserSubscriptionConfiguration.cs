using CodeApp.Domain.Entities.Subscription;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeApp.Persistence.Configurations;

public class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
{
    public void Configure(EntityTypeBuilder<UserSubscription> builder)
    {
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.ProductId).HasMaxLength(200).IsRequired();
        builder.Property(x => x.OriginalTransactionId).HasMaxLength(200).IsRequired();
        builder.Property(x => x.TransactionId).HasMaxLength(200);
        builder.Property(x => x.RawPayload).HasColumnType("text");

        builder.HasIndex(x => new { x.Provider, x.OriginalTransactionId }).IsUnique();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
