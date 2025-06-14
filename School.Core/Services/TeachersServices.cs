using School.Core.Dtos.Delete;
using School.Core.Dtos.Requests.Teachers;
using School.Core.Mapping;
using School.Database.Repositories;

namespace School.Core.Services
{
    public class TeachersServices(TeachersRepository teachersRepository, SubjectsRepository subjectsRepository)
    {

        public async Task AddTeacherAsync(AddTeacherRequest payload)
        {
            var newTeacher = payload.ToEntity();

            teachersRepository.Insert(newTeacher);
            await teachersRepository.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(DeletePayload payload)
        {
            var teacher = teachersRepository.GetFirstOrDefaultAsync(payload.Id).Result;

            if (teacher == null)
            {
                throw new Exception($"Teacher with ID {payload.Id} was not found.");
            }

            var subjects = await subjectsRepository.GetAllByTeacherIdAsync(teacher.Id);

            foreach (var subject in subjects)
            {
                await subjectsRepository.SoftDeleteAsync(subject);
            }

            await teachersRepository.SoftDeleteAsync(teacher);
        }
    }
}
