using School.Database.Entities;
using School.Database.Context;
using Microsoft.EntityFrameworkCore;


namespace School.Database.Repositories
{
    public class StudentsRepository: BaseRepository<Student>
    {
        public StudentsRepository(SchoolDatabaseContext context) : base(context)
        {
            this.schoolDatabaseContext = context;
            Console.WriteLine("StudentsRepository initialized");
        }

        public async Task AddAsync(Student student)
        {
          schoolDatabaseContext.Students.Add(student);
           await schoolDatabaseContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync ()
        {
            var result = await schoolDatabaseContext.Students
                .Where(s => s.DeletedAt == null)
                .OrderBy(s => s.LastName)
                .ToListAsync();
            return result;
        }

        public async Task<Student?> GetByIdAsync(int studentId)
        {
            var result = await schoolDatabaseContext.Students
                .Where(s => s.DeletedAt == null)
                .FirstOrDefaultAsync(s => s.Id == studentId);
            return result;
        }

        public async Task<Student> GetByNameAsync(string firstName, string lastName)
        {
            var result = await schoolDatabaseContext.Students
            .Include(s => s.Grades)
             .Where(s => s.DeletedAt == null)
             .Where(s => s.FirstName == firstName && s.LastName == lastName)
             .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Student>> GetAllWithGradesAsync()
        {
            return await schoolDatabaseContext.Students
                .Include(s => s.Grades)
                .Where(s => s.DeletedAt == null)
                .OrderBy(s => s.LastName)
                .ToListAsync();
        }

    }
}
