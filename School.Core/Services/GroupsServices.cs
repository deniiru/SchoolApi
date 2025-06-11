using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Core.Dtos.Requests.Groups;
using School.Database.Entities;
using School.Database.Repositories;
using School.Core.Mapping;

namespace School.Core.Services
{
    public class GroupsServices
    {
        private readonly GroupsRepository groupsRepository;
        public GroupsServices(GroupsRepository groupsRepository)
        {
            this.groupsRepository = groupsRepository;
            Console.WriteLine("StudentsServices initialized");
        }

        public async Task AddGroupAsync (AddGroupRequest payload)
        {
            var group = payload.ToEntity();
            groupsRepository.Insert(group);
            await groupsRepository.SaveChangesAsync();
            Console.WriteLine($"{payload.GroupName} added successfully.");
        }
    }
}
