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

        public MajorsServices( MajorsRepository majorsRepository)
        {
            this.majorRepository = majorsRepository;
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

            await majorRepository.SoftDeleteAsync(major);
        }
    }
}
