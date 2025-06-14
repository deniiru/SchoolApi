using School.Core.Dtos.Requests.Teachers;
using School.Core.Mapping;
using School.Database.Repositories;

namespace School.Core.Services
{
    public class TeachersServices(TeachersRepository teachersRepository)
    {

        public async Task AddTeacherAsync(AddTeacherRequest payload)
        {
            var newTeacher = payload.ToEntity();

            teachersRepository.Insert(newTeacher);
            await teachersRepository.SaveChangesAsync();
        }
    }
}
