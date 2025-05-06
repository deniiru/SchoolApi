using Microsoft.EntityFrameworkCore;
using School.Database.Entities;
using School.Infrastructure.Config;
using System;

namespace School.Database.Context
{
    public class SchoolDatabaseContext : DbContext
    {
     
        public SchoolDatabaseContext () { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionStrings?.SchoolDatabase);//.LogTo(Console.WriteLine);

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
