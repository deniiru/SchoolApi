using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using School.Database.Context;
using School.Database.Entities;
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

                //.AsNoTracking()
                .ToListAsync();

            return results;
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


    }
}
