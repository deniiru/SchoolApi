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
            services.AddScoped<GroupsServices>();
            services.AddScoped<MajorsServices>();
            services.AddScoped<TeachersServices>();
            services.AddScoped<SubjectsServices>();
            services.AddScoped<UsersServices>();
            services.AddScoped<AuthService>();
            return services;
        }
    }
}
