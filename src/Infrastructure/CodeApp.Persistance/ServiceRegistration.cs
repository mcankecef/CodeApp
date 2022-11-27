using CodeApp.Application.Repositories;
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
        public static void AddPersistanceRegistration(this IServiceCollection services ,IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddDbContext<CodeAppDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
        }
    }
}
