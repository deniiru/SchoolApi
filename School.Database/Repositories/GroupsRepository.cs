using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Database.Context;
using School.Database.Dtos;
using School.Database.Entities;

namespace School.Database.Repositories
{
    public class GroupsRepository(SchoolDatabaseContext schoolDatabaseContext) : BaseRepository<Group>(schoolDatabaseContext)
    {
   
    }
}
