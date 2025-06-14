using School.Database.Context;
using School.Database.Entities;

namespace School.Database.Repositories
{
    public class MajorsRepository: BaseRepository<Major>
    {
        public MajorsRepository(SchoolDatabaseContext context) : base(context)
        {
            this.schoolDatabaseContext = context;
            Console.WriteLine("StudentsRepository initialized");
        }

        public async Task AddAsync(Major major)
        {
            schoolDatabaseContext.Major.Add(major);
            await schoolDatabaseContext.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(Major major)
        {
            major.DeletedAt = DateTime.Now;
            await schoolDatabaseContext.SaveChangesAsync();
        }
    }
}
