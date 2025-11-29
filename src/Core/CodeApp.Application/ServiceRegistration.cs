using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CodeApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
