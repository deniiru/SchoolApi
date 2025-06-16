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
            var grade = new Grade
            {
                Score = payload.Score,
                StudentId = payload.StudentId,
                SubjectId = payload.SubjectId,
            };
            grade.CreatedAt = DateTime.UtcNow;
            return grade;
        }

        public static GradeDto ToGradeDto(this Grade grade)
        {
            if (grade == null) return null;

            return new GradeDto
            {
                Id = grade.Id,
                SubjectId = grade.SubjectId,
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
