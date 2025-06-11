using School.Core.Dtos.Requests.Majors;
using School.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Mapping
{
    public static class MajorMappingExtension
    {
        public static Major ToEntity(this AddMajorRequest payload)
        {
            var major = new Major
            {
                Name = payload.Name
            };
            major.CreatedAt = DateTime.UtcNow;
            return major;
        }
    }
}
