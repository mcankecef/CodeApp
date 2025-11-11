using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeApp.Persistence.Contexts
{
    public class CodeAppDbContextFactory : IDesignTimeDbContextFactory<CodeAppDbContext>
    {
        public CodeAppDbContext CreateDbContext(string[] args)
        {
            // Create DbContext with the connection string from appsettings.json
            var optionsBuilder = new DbContextOptionsBuilder<CodeAppDbContext>();
            
            // Use the connection string from your appsettings.json
            var connectionString = "workstation id=codeapp_db.mssql.somee.com;packet size=4096;user id=codeapp_SQLLogin_1;pwd=2glf3lr9qb;data source=codeapp_db.mssql.somee.com;persist security info=False;initial catalog=codeapp_db;TrustServerCertificate=True";
            
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());

            return new CodeAppDbContext(optionsBuilder.Options);
        }
    }
}