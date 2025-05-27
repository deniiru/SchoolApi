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
                LastName = payload.LastName
            };
        }

        // Converts a list of Student entities to a list of StudentDto
        public static List<StudentDto> ToStudentDto(this List<Student> students)
        {
            if (students == null) return new List<StudentDto>();

            return students.Select(s => s.ToStudentDto()).ToList();
        }

        public static StudentDto ToStudentDto(this Student student)
        {
            if (student == null) return null;

            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grades = student.Grades?.ToGradeDtos()
            };
        }
    }
}
