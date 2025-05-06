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
    public class GradesRepository : BaseRepository<Grade>
    {
        public GradesRepository(SchoolDatabaseContext schoolDatabaseContext) : base(schoolDatabaseContext)
        {
            this.schoolDatabaseContext = schoolDatabaseContext;
        }

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
    }
}
