using CodeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeApp.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x=>x.CorrectAnswer).IsRequired();
            builder.Property(x=>x.Score).IsRequired();
            builder.Property(x=>x.LanguageId).IsRequired();

            // Language
            builder.HasOne(x=>x.Language)
                .WithMany(x=>x.Questions)
                .HasForeignKey(x=>x.LanguageId);
        }
    }
}
