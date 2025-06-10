using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using School.Database.Entities;
using School.Infrastructure.Config;

namespace School.Database.Context
{
    public class SchoolDatabaseContextFactory : IDesignTimeDbContextFactory<SchoolDatabaseContext>
    {
        public SchoolDatabaseContext CreateDbContext(string[] args)
        { 
            var builder = new ConfigurationBuilder()
                 .SetBasePath($"{Directory.GetCurrentDirectory()}")
                 .AddJsonFile($"appsettings.Development.json");

            var configuration = builder.Build();
            AppConfig.Init(configuration);

            return new SchoolDatabaseContext();
        }
    }
}
