using Microsoft.Extensions.DependencyInjection;
using School.Core.Services;

namespace School.Core
{
    public static class DIConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
             services.AddScoped<StudentsServices>();
            services.AddScoped<GradesServices>();
            return services;
        }
    }
}
