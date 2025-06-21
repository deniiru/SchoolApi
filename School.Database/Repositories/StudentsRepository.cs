using Microsoft.EntityFrameworkCore;
using School.Database.Context;
using School.Database.Dtos;
using School.Database.Entities;
using School.Database.Enums;
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

        public async Task AddAsync(Student student)
        {
            schoolDatabaseContext.Students.Add(student);
            await schoolDatabaseContext.SaveChangesAsync();
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

        //public async Task<List<Student>> GetAllWithGradesAsync(StudentsFilteringDto filters, StudentsSortingDto sortingOption)
        //{
        //    var students = await schoolDatabaseContext.Students
        //     .Include(s => s.Grades)
        //     .Where(s => s.DeletedAt == null)

        //     .Where(s => string.IsNullOrEmpty(filters.SearchValue) ||
        //                 s.FirstName.ToLower().Contains(filters.SearchValue.ToLower()) ||
        //                 s.LastName.ToLower().Contains(filters.SearchValue.ToLower()))

        //     .Where(s => filters.DateRange == null ||
        //                 s.Grades.Any(g =>
        //                     (!filters.DateRange.LowerGrade.HasValue || g.Score >= filters.DateRange.LowerGrade.Value) &&
        //                     (!filters.DateRange.UpperGrade.HasValue || g.Score <= filters.DateRange.UpperGrade.Value)))

        //     .SortBy(sortingOption)

        //     .Skip(filters.Skip)
        //     .Take(filters.Take)

        //     .AsNoTracking()
        //     .ToListAsync();

        //    return students;
        //}


        public async Task<List<Student>> GetFilterStudentsAsync (StudentsFilteringDto filters, StudentsSortingDto sortingOption)
        {
            var students = schoolDatabaseContext.Students
                .Include( s => s.Group).ThenInclude( g => g.Major)
                .Where( s => s.DeletedAt == null)
                .Where( s => s.Group.DeletedAt == null)
                .Where( s=> s.Group.Major.DeletedAt == null)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.FirstName) && filters.FirstName!= "string")
                students = students.Where(s => s.FirstName.Contains(filters.FirstName));

            if (!string.IsNullOrWhiteSpace(filters.LastName) && filters.LastName != "string")
                students = students.Where(s => s.LastName.Contains(filters.LastName));

            if (!string.IsNullOrWhiteSpace(filters.Group) && filters.Group != "string")
                students = students.Where(s => s.Group.Name.Contains(filters.Group));

            if (!string.IsNullOrWhiteSpace(filters.Major) && filters.Major != "string")
                students = students.Where(s => s.Group.Major.Name.Contains(filters.Major));

            if (filters.Year != YearEnum.None)
                students = students.Where(s => s.Group.An == filters.Year);

            students = students
                .Skip(filters.Skip)
                .Take(filters.Take)
                .SortBy(sortingOption);

            return await students.ToListAsync();
        }

        public async Task SoftDeleteAsync(Student student)
        {
            student.DeletedAt = DateTime.Now;
            await SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllByGroupAsync(int id)
        {
            var students = await schoolDatabaseContext.Students
                .Where(s => s.GroupId == id).ToListAsync();

            return students;
        }

        public async Task<List<Grade>> GetAllGradesForStudentInSubjectAsync(int studentId, int subjectId)
        {
            return await schoolDatabaseContext.Grades
                .Where(g => g.SubjectId == subjectId && g.StudentId == studentId).ToListAsync();
        }

        public async Task<List<Student>> GetStudentsFromGroupAsync(int groupId)
        {
            return await schoolDatabaseContext.Students
                .Where(s => s.DeletedAt == null && s.GroupId == groupId)
                .ToListAsync();
        }

    }
}
