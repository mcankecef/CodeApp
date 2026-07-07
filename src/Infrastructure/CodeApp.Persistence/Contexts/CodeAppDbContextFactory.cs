using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeApp.Persistence.Contexts
{
    public class CodeAppDbContextFactory : IDesignTimeDbContextFactory<CodeAppDbContext>
    {
        private const string DesignTimeConnectionString =
            "Server=localhost;Database=CodeApp;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";

        public CodeAppDbContext CreateDbContext(string[] args)
        {
            var connectionString =
                Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                ?? Environment.GetEnvironmentVariable("ConnectionStrings:DefaultConnection")
                ?? DesignTimeConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<CodeAppDbContext>();
            optionsBuilder.UseSqlServer(connectionString, sqlOptions =>
                sqlOptions.EnableRetryOnFailure());

            return new CodeAppDbContext(optionsBuilder.Options);
        }
    }
}
