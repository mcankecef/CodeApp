using CodeApp.Domain.Entities;
using CodeApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodeApp.Persistance.Contexts
{
    public class CodeAppDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public CodeAppDbContext(DbContextOptions<CodeAppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
