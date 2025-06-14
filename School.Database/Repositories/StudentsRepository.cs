using Microsoft.EntityFrameworkCore;
using School.Database.Context;
using School.Database.Dtos;
using School.Database.Entities;
using School.Database.QueryExtensions;


namespace School.Database.Repositories
{
    public class StudentsRepository : BaseRepository<Student>
    {
        public StudentsRepository(SchoolDatabaseContext context) : base(context)
        {
            this.schoolDatabaseContext = context;
            Console.WriteLine("StudentsRepository initialized");
        }

        public async Task<List<Student>> GetAllAsync()
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

        public async Task<List<Student>> GetAllWithGradesAsync(StudentsFilteringDto filters, StudentsSortingDto sortingOption)
        {
            var students = await schoolDatabaseContext.Students
             .Include(s => s.Grades)
             .Where(s => s.DeletedAt == null)

             .Where(s => string.IsNullOrEmpty(filters.SearchValue) ||
                         s.FirstName.ToLower().Contains(filters.SearchValue.ToLower()) ||
                         s.LastName.ToLower().Contains(filters.SearchValue.ToLower()))

             .Where(s => filters.DateRange == null ||
                         s.Grades.Any(g =>
                             (!filters.DateRange.LowerGrade.HasValue || g.Score >= filters.DateRange.LowerGrade.Value) &&
                             (!filters.DateRange.UpperGrade.HasValue || g.Score <= filters.DateRange.UpperGrade.Value)))

             .SortBy(sortingOption)

             .Skip(filters.Skip)
             .Take(filters.Take)

             .AsNoTracking()
             .ToListAsync();

            return students;
        }


    }
}
