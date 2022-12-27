using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities.Identity;
using CodeApp.Persistance.Contexts;
using CodeApp.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CodeApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddDbContext<CodeAppDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], options => options.EnableRetryOnFailure()));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                //options.User.AllowedUserNameCharacters 
            }).AddEntityFrameworkStores<CodeAppDbContext>();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
        }
    }
}
