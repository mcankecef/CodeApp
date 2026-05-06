using CodeApp.Application.Abstractions;
using CodeApp.Application.Abstractions.Services;
using CodeApp.Application.Repositories;
using CodeApp.Application.Repositories.AppUserStepQuestion;
using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Application.Repositories.UserStreak;
using CodeApp.Domain.Entities.Identity;
using CodeApp.Persistence.Contexts;
using CodeApp.Persistence.Repositories;
using CodeApp.Persistence.Repositories.AppUserStepQuestion;
using CodeApp.Persistence.Repositories.StepQuestion;
using CodeApp.Persistence.Repositories.UserStreak;
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

            services.AddDbContext<CodeAppDbContext>(options =>
                options.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]));
            
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<CodeAppDbContext>();

            // Disable cookie redirect for API
            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                };
            });


            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));

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

            services.AddTransient<IStepQuestionReadRepository, StepQuestionReadRepository>();
            services.AddTransient<IStepQuestionWriteRepository, StepQuestionWriteRepository>();
            services.AddTransient<IAppUserStepQuestionReadRepository, AppUserStepQuestionReadRepository>();
            services.AddTransient<IAppUserStepQuestionWriteRepository, AppUserStepQuestionWriteRepository>();

            services.AddTransient<IUserStreakReadRepository, UserStreakReadRepository>();
            services.AddTransient<IUserStreakWriteRepository, UserStreakWriteRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
        }
    }
}
