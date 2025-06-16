using School.Database.Context;
using School.Database.Entities;

namespace School.Database.Repositories
{
    public class TeachersRepository(SchoolDatabaseContext schoolDatabaseContext) : BaseRepository<Teacher>(schoolDatabaseContext)
    {
        public async Task SoftDeleteAsync(Teacher teacher)
        {
            teacher.DeletedAt = DateTime.Now;
            await schoolDatabaseContext.SaveChangesAsync();
        }
    }
}
