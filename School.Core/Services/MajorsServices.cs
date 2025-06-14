using School.Core.Dtos.Delete;
using School.Core.Dtos.Requests.Majors;
using School.Core.Mapping;
using School.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Services
{
    public class MajorsServices
    {
        private readonly MajorsRepository majorRepository;
        private readonly GroupsRepository groupsRepository;
        private readonly SubjectsRepository subjectsRepository;

        public MajorsServices( MajorsRepository majorsRepository, GroupsRepository groupsRepository)
        {
            this.majorRepository = majorsRepository;
            this.groupsRepository = groupsRepository;
        }

        public async Task AddMajorAsync (AddMajorRequest payload)
        {
            var major = payload.ToEntity();
            await majorRepository.AddAsync (major);
        }

        public async Task DeleteMajorAsync(DeletePayload payload)
        {
            var major = majorRepository.GetFirstOrDefaultAsync(payload.Id).Result;

            if(major == null)
            {
                throw new Exception($"Major with ID {payload.Id} was not found.");
            }

            var gropus = await groupsRepository.GetAllByMajorIdAsync(major.Id);

            foreach (var group in gropus)
            {
                await groupsRepository.SoftDeleteAsync(group);
            }

            var subjects = await subjectsRepository.GetAllByMajorIdAsync(major.Id);

            foreach(var subject in subjects)
            {
                await subjectsRepository.SoftDeleteAsync(subject);
            }

            await majorRepository.SoftDeleteAsync(major);
        }
    }
}
