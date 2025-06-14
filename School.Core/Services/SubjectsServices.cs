using School.Core.Dtos.Requests.Subjects;
using School.Core.Mapping;
using School.Database.Repositories;

namespace School.Core.Services
{
    public class SubjectsServices(SubjectsRepository subjectsRepository)
    {
        public async Task AddSubjectAsync(AddSubjectRequest payload)
        {
            var newSubject = payload.ToEntity();
            subjectsRepository.Insert(newSubject);
            await subjectsRepository.SaveChangesAsync();
        }
    }
}
