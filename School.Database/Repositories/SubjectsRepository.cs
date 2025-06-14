using Microsoft.EntityFrameworkCore;
using School.Database.Context;
using School.Database.Entities;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Repositories
{
    public class SubjectsRepository(SchoolDatabaseContext schoolDatabaseContext) : BaseRepository<Subject>(schoolDatabaseContext)
    {
        public async Task<List<Subject>> GetAllByTeacherIdAsync(int id)
        {
            return await schoolDatabaseContext.Subjects.Where(s => s.TeacherId == id).ToListAsync();
        }

        public async Task<List<Subject>> GetAllByMajorIdAsync(int id)
        {
            return await schoolDatabaseContext.Subjects.Where(s => s.MajorId == id).ToListAsync();
        }

        public async Task SoftDeleteAsync(Subject subject)
        {
            subject.DeletedAt = DateTime.Now;
            await schoolDatabaseContext.SaveChangesAsync();
        }
    }
}
