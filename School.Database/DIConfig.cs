using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Database.Context;
using School.Database.Repositories;

namespace School.Database
{
    public static class DIConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<SchoolDatabaseContext>();
            services.AddScoped<DbContext, SchoolDatabaseContext>();
            services.AddScoped<StudentsRepository>();
            services.AddScoped<GradesRepository>();

            return services;
        }
    }
}
