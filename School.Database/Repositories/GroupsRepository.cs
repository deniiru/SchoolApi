using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using School.Database.Context;
using School.Database.Dtos;
using School.Database.Entities;

namespace School.Database.Repositories
{
    public class GroupsRepository(SchoolDatabaseContext schoolDatabaseContext) : BaseRepository<Group>(schoolDatabaseContext)
    {
        //public GroupsRepository() : base(context)
        //{
        //    this.schoolDatabaseContext = context;
        //    Console.WriteLine("StudentsRepository initialized");
        //}

        public async Task AddAsync(Group group)
        {

            schoolDatabaseContext.Groups.Add(group);
            await schoolDatabaseContext.SaveChangesAsync();
        }
    }
}
