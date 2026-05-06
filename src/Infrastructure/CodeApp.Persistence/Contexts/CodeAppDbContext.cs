using CodeApp.Domain.Entities;
using CodeApp.Domain.Entities.Identity;
using CodeApp.Domain.Entities.Subscription;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace CodeApp.Persistence.Contexts
{
    public class CodeAppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public CodeAppDbContext(DbContextOptions<CodeAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            ApplyPostgresLowercaseNaming(modelBuilder);
        }

        public DbSet<Language> Languages { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Avatar> Avatars { get; set; } = null!;
        public DbSet<StepQuestion> StepQuestions { get; set; } = null!;
        public DbSet<AppUserStepQuestion> AppUserStepQuestions { get; set; } = null!;
        public DbSet<UserStreak> UserStreaks { get; set; } = null!;
        public DbSet<UserSubscription> UserSubscriptions { get; set; } = null!;

        private static void ApplyPostgresLowercaseNaming(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (!string.IsNullOrWhiteSpace(tableName))
                {
                    entity.SetTableName(tableName.ToLowerInvariant());
                }

                var storeObject = StoreObjectIdentifier.Table(entity.GetTableName()!, entity.GetSchema());

                foreach (var property in entity.GetProperties())
                {
                    var columnName = property.GetColumnName(storeObject);
                    if (!string.IsNullOrWhiteSpace(columnName))
                    {
                        property.SetColumnName(columnName.ToLowerInvariant());
                    }
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName()?.ToLowerInvariant());
                }

                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.ToLowerInvariant());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName()?.ToLowerInvariant());
                }
            }
        }
    }
}
