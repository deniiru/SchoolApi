using School.Database.Context;
using School.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
