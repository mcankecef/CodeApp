using CodeApp.Domain.Entities;
using CodeApp.Domain.Entities.Identity;
using CodeApp.Domain.Entities.Subscription;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    }
}
