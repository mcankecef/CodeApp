using MediatR;
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

            services.AddMediatR(assembly);
        }
    }
}
