using School.Database.Context;
using School.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Repositories
{
    public class SubjectsRepository(SchoolDatabaseContext schoolDatabaseContext): BaseRepository<Subject> (schoolDatabaseContext)
    {
    }
}
