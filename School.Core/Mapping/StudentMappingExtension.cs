using School.Core.Dtos.Requests.Students;
using School.Database.Entities;
using System.Runtime.CompilerServices;

namespace School.Core.Mapping
{
    public static class StudentMappingExtension
    {
        public static Student ToEntity( this AddStudentRequest payload)
        {
            var student = new Student();

            student.FirstName = payload.FirstName;
            student.LastName = payload.LastName;
            return student;
        }
    }
}
