using School.Core.Dtos.Requests.Teachers;
using School.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Mapping
{
    public static class TeacherMappingExtension
    {
     
        public static Teacher ToEntity(this AddTeacherRequest payload)
        {
            var teacher = new Teacher
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName
                
            };
            teacher.CreatedAt = DateTime.UtcNow;
            return teacher;
        }
    }
}
