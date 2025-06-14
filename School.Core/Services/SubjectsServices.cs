using School.Core.Dtos.Delete;
using School.Core.Dtos.Requests.Subjects;
using School.Core.Mapping;
using School.Database.Repositories;

namespace School.Core.Services
{
    public class SubjectsServices(SubjectsRepository subjectsRepository, GradesRepository gradesRepository)
    {
        public async Task AddSubjectAsync(AddSubjectRequest payload)
        {
            var newSubject = payload.ToEntity();
            subjectsRepository.Insert(newSubject);
            await subjectsRepository.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(DeletePayload payload)
        {
            var subject = subjectsRepository.GetFirstOrDefaultAsync(payload.Id).Result;

            if (subject == null)
            {
                throw new Exception($"Subject with ID {payload.Id} was not found.");
            }

            var grades = await gradesRepository.GetBySubjectIdAsync(subject.Id);

            foreach (var grade in grades)
            {
                await gradesRepository.SoftDeleteAsync(grade);
            }

            await subjectsRepository.SoftDeleteAsync(subject);
        }
    }
}
