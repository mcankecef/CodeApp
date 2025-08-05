using CodeApp.Application.Abstractions;
using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities.Identity;
using CodeApp.Persistence.Contexts;
using CodeApp.Persistence.Repositories;
using CodeApp.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CodeApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
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


            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ILanguageReadRepository, LanguageReadRepository>();
            services.AddTransient<ILanguageWriteRepository, LanguageWriteRepository>();

            services.AddTransient<IQuestionReadRepository, QuestionReadRepository>();
            services.AddTransient<IQuestionWriteRepository, QuestionWriteRepository>();

            services.AddTransient<IAnswerReadRepository, AnswerReadRepository>();
            services.AddTransient<IAnswerWriteRepository, AnswerWriteRepository>();

            services.AddTransient<ISubjectReadRepository, SubjectReadRepository>();
            services.AddTransient<ISubjectWriteRepository, SubjectWriteRepository>();

            services.AddTransient<IAvatarReadRepository, AvatarReadRepository>();
            services.AddTransient<IAvatarWriteRepository, AvatarWriteRepository>();

            services.AddTransient<IUserService, UserService>();
        }
    }
}
