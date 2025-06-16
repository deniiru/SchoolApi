using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Core.Dtos.Requests.Groups;
using School.Database.Entities;
using School.Database.Repositories;
using School.Core.Mapping;
using School.Core.Dtos.Delete;

namespace School.Core.Services
{
    public class GroupsServices
    {
        private readonly GroupsRepository groupsRepository;
        private readonly StudentsRepository studentsRepository;
        public GroupsServices(GroupsRepository groupsRepository, StudentsRepository studentsRepository)
        {
            this.groupsRepository = groupsRepository;
            this.studentsRepository = studentsRepository;
        }

        public async Task AddGroupAsync (AddGroupRequest payload)
        {
            var group = payload.ToEntity();
            groupsRepository.Insert(group);
            await groupsRepository.SaveChangesAsync();
            Console.WriteLine($"{payload.GroupName} added successfully.");
        }

        public async Task AdvanceAllGroupsAsync()
        {
            var groups = await groupsRepository.GetAllAsync();
            foreach (var group in groups)
            {
                if (group.An != Database.Enums.YearEnum.DoneWithCollege)
                {
                    group.An += 1;
                }
            }
            groupsRepository.Update();
            await groupsRepository.SaveChangesAsync ();
        }

        public async Task DeleteGroupAsync(DeletePayload payload)
        {
            var group = groupsRepository.GetFirstOrDefaultAsync(payload.Id).Result;

            if (group == null)
            {
                throw new Exception($"Group with ID {payload.Id} was not found.");
            }

            var Students = await studentsRepository.GetAllByGroupAsync(group.Id);
            foreach (var student in Students)
            {
                await studentsRepository.SoftDeleteAsync(student);
            }
            await groupsRepository.SoftDeleteAsync(group);
        }
    }
}
