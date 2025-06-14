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
        public async Task<List<Group>> GetAllByMajorIdAsync(int id)
        {
            return await schoolDatabaseContext.Groups.Where(g => g.MajorId == id).ToListAsync();
        }

        public async Task SoftDeleteAsync(Group group)
        {
            group.DeletedAt = DateTime.Now;
            await schoolDatabaseContext.SaveChangesAsync();
        }
    }
}
