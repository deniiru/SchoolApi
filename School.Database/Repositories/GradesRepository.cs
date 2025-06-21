using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using School.Database.Context;
using School.Database.Dtos;
using School.Database.Entities;
using School.Database.Enums;
using School.Database.QueryExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Repositories
{
    public class GradesRepository(SchoolDatabaseContext schoolDatabaseContext) : BaseRepository<Grade>(schoolDatabaseContext)
    {

        public async Task AddAsync(Grade entity)
        {
            schoolDatabaseContext.Grades.Add(entity);
            await SaveChangesAsync();
        }

        public async Task<List<Grade>> GetAllAsync()
        {
            var results = await schoolDatabaseContext.Grades
                .Where(g => g.DeletedAt == null)

                .OrderBy(g => g.Subject)

                .ToListAsync();

            return results;
        }

        public async Task SoftDeleteAsync(Grade g)
        {
            g.DeletedAt = DateTime.UtcNow;
            await SaveChangesAsync();
        }

        public async Task<Grade?> GetByIdAsync(int id)
        {
            return await schoolDatabaseContext.Grades
                .FirstOrDefaultAsync(g => g.Id == id && g.DeletedAt == null);
        }

        public async Task UpdateAsync(Grade entity)
        {
            entity.ModifiedAt= DateTime.UtcNow; // Set updated timestamp

            schoolDatabaseContext.Grades.Update(entity);
            await SaveChangesAsync();
        }

        public async Task<List<Grade>> GetByStudentIdAsync(int id)
        {
            return await schoolDatabaseContext.Grades.Where(g => g.StudentId == id).ToListAsync();
        }

        public async Task<List<Grade>> GetByStudentIdFilteredAsync (int idStudent, GradesFilteringDto filters, GradesSortingDto sortingOption)
        {

            var grades = schoolDatabaseContext.Grades
              .Include(g => g.Subject)
              .Where(g => g.DeletedAt == null && g.StudentId ==idStudent)
              .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.Subject) && filters.Subject != "string")
                grades = grades.Where(s => s.Subject.Name == filters.Subject);

            if (filters.Year != YearEnum.None)
                grades = grades.Where(g => g.Subject.Year == filters.Year);

            grades = grades
                .Skip(filters.Skip)
                .Take(filters.Take)
                .SortBy(sortingOption);

            return await grades.ToListAsync();
        }

        public async Task<List<Grade>> GetBySubjectIdAsync(int id)
        {
            return await schoolDatabaseContext.Grades.Where(g => g.SubjectId == id).ToListAsync();
        }
    }
}
