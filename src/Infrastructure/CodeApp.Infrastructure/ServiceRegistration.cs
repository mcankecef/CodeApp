using CodeApp.Application.Abstractions;
using CodeApp.Application.Abstractions.Services;
using CodeApp.Application.Token;
using CodeApp.Infrastructure.Services;
using CodeApp.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CodeApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler,TokenHandler>();
            services.AddScoped<IStreakService, StreakService>();
            services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            services.AddHttpClient<IEmailService, BrevoEmailService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
