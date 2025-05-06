using School.Core.Dtos.Requests.Students;
using School.Database.Entities;
using System;
using School.Core.Dtos.Requests.Grades;

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
    }
}
