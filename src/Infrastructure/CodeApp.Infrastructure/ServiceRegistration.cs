using CodeApp.Application.Token;
using CodeApp.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace CodeApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler,TokenHandler>();
        }
    }
}
