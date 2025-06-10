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
        public DbSet<Group> Groups { get; set; }
        public DbSet<Major> Major { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(n => n.Group)
                .WithMany(s => s.Studentii)
                .HasForeignKey(n => n.GroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
