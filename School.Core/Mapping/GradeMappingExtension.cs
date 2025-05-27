using School.Core.Dtos.Requests.Students;
using School.Database.Entities;
using System;
using School.Core.Dtos.Requests.Grades;
using School.Core.Dtos.Common.Grades;

namespace School.Core.Mapping
{
    public static class GradeMappingExtension
    {
        public static Grade ToEntity(this AddGradeRequest payload)
        {
            var grade = new Grade();
            grade.Subject = payload.Subject;
            grade.Score = payload.Score;
            grade.StudentId = payload.StudentId;
            return grade;
        }

        public static GradeDto ToGradeDto(this Grade grade)
        {
            if (grade == null) return null;

            return new GradeDto
            {
                Id = grade.Id,
                Subject = grade.Subject,
                Score = grade.Score
            };
        }

        public static List<GradeDto> ToGradeDtos(this List<Grade> grades)
        {
            if (grades == null) return new List<GradeDto>();

            return grades.Select(g => g.ToGradeDto()).ToList();
        }
    }
}
