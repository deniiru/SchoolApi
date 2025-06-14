using School.Core.Dtos.Common.Grades;
using School.Core.Dtos.Common.Students;
using School.Core.Dtos.Requests.Students;
using School.Core.Dtos.Responses.Students;
using School.Core.Mapping;
using School.Database.Entities;
using School.Database.Repositories;


namespace School.Core.Services
{
    public class StudentsServices
    {
        private readonly StudentsRepository studentsRepository;
     

        public StudentsServices(StudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public async Task AddStudentAsync(AddStudentRequest payload)
        {
            var newStudent = payload.ToEntity();
            newStudent.CreatedAt = DateTime.UtcNow;

            studentsRepository.Insert(newStudent);
            await studentsRepository.SaveChangesAsync();
        }

        public async Task<GetStudentsResponse> GetAllStudentsAsync()
        {
            var students = await studentsRepository.GetAllAsync();

            var result = new GetStudentsResponse();

            result.Students = students.Select(
                s => new StudentDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList();

            return result;
        }


        public async Task<StudentDto> GetStudentByIdAsync(int studentId)
        {
            var student = await studentsRepository.GetByIdAsync(studentId);
            if (student == null)
            {
                throw new Exception($"Student with ID {studentId} not found.");
            }
            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }

        //public async Task<GetStudentsResponse> GetStudentByNameAsync(AddStudentRequest payload)
        //{
        //    var students = await studentsRepository.GetByNameAsync(payload.FirstName, payload.LastName);
        //    if (students == null)
        //    {
        //        throw new Exception($"Student not found.");
        //    }
        //    var result = new GetStudentsResponse();

        //    result.Students = students.Select(
        //        s => new StudentDto
        //        {
        //            Id = s.Id,
        //            FirstName = s.FirstName,
        //            LastName = s.LastName
        //        }).ToList();

        //    return result;
        //}

        public async Task<GetStudentsGradesResponse> GetStudentsWithGradesAsync()
        {
            var students = await studentsRepository.GetAllWithGradesAsync();

            var result = new GetStudentsGradesResponse();

            result.Students = students.Select(
                s => new StudentDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Grades = s.Grades.Select(g => new GradeDto
                    {
                        Id = g.Id,
                        StudentId = g.StudentId,
                        SubjectId = g.SubjectId,
                        Score = g.Score
                    }).ToList()

                }).ToList();

            return result;
        }



        public async Task<GetStudentsGradesResponse> GetFilteredStudentsWithGradesAsync(GetFilterdStudentsRequest payload)
        {
            var students = await studentsRepository.GetAllWithGradesAsync(payload.Filters, payload.SortingOption);

            var result = new GetStudentsGradesResponse();

            result.Students = students.ToStudentDto();

            return result;
        }
    }
}
