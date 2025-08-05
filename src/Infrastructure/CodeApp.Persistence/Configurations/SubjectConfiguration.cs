using CodeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeApp.Persistence.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(b => b.Title).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Description).IsRequired();

            // Language
            builder.HasOne(b=>b.Language)
                .WithMany(b=>b.Subjects)
                .HasForeignKey(b=>b.LanguageId);
                
        }
    }
}
