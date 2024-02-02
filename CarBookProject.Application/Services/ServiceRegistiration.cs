using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CarBookProject.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }
}
