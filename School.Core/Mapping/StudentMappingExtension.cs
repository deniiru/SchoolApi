using School.Core.Dtos.Common.Students;
using School.Core.Dtos.Requests.Students;
using School.Database.Entities;
using System.Runtime.CompilerServices;

namespace School.Core.Mapping
{
    public static class StudentMappingExtension
    {
        public static Student ToEntity(this AddStudentRequest payload)
        {
            if (payload == null) return null;

            return new Student
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                GroupId = payload.GroupId,
            };
        }
    }
}
