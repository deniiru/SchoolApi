using School.Core.Dtos.Requests.Subjects;
using School.Database.Entities;

namespace School.Core.Mapping
{
    public static class SubjectMappingExtention
    {
        public static Subject ToEntity(this AddSubjectRequest payload)
        {
            var subject = new Subject
            {
                Name = payload.Name,
                TeacherId = payload.TeacherId,
                Year = payload.Year,
                MajorId = payload.MajorId
            };
            subject.CreatedAt = DateTime.UtcNow;
            return subject;
        }
    }
}
