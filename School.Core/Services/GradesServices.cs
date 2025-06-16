using School.Database.Repositories;
using School.Core.Dtos.Requests.Grades;
using School.Core.Dtos.Responses.Grades;
using School.Core.Dtos.Common.Grades;
using School.Core.Mapping;
using School.Core.Dtos.Requests.Students;
using School.Core.Dtos.Delete;

namespace School.Core.Services
{
    public class GradesServices
    {
        private readonly StudentsServices studentsServices;
        private readonly GradesRepository gradesRepository;

        public GradesServices(StudentsServices studentsServices, GradesRepository gradesRepository)
        {
            this.studentsServices = studentsServices;
            this.gradesRepository = gradesRepository;
            Console.WriteLine("GradesService initialized");
            this.gradesRepository = gradesRepository;
        }

        public async Task AddGradeAsync(AddGradeRequest payload)
        {
            //var students = await studentsServices.GetStudentByIdAsync(payload.StudentId);

            //if (students == null)
            //{
            //    throw new Exception($"Student with ID {payload.StudentId} not found.");
            //}

            var newEvent = payload.ToEntity();
            gradesRepository.Insert(newEvent);
            await gradesRepository.SaveChangesAsync();
        }

        public async Task DeleteGradeAsync(DeletePayload payload)
        {
            var grade = await gradesRepository.GetByIdAsync(payload.Id);

            if (grade == null) 
            {
                throw new Exception($"Grade with ID {payload.Id} not found.");
            }

            await gradesRepository.SoftDeleteAsync(grade);
        }

        public async Task UpdateGradeAsync(UpdateGradeRequest request)
        {
           
            var grade = await gradesRepository.GetByIdAsync(request.Id);
            if (grade == null)
            {
                throw new Exception($"Grade with ID {request.Id} not found.");
            }

            var student = await studentsServices.GetStudentByIdAsync(request.StudentId);
            if (student == null)
            {
                throw new Exception($"Student with ID {request.StudentId} not found.");
            }

            grade.SubjectId = request.SubjectId;
            grade.Score = request.Score;
            grade.StudentId = request.StudentId;

            
            await gradesRepository.UpdateAsync(grade);
        }

        public async Task<GetGradesResponse> GetAllGradesAsync()
        {
            var grades = await gradesRepository.GetAllAsync();
            var result = new GetGradesResponse();
            result.Grades = grades.Select(
                g => new GradeDto
                {
                    Id = g.Id,
                    StudentId = g.StudentId,
                    SubjectId = g.SubjectId,
                    Score = g.Score,
                }).ToList();
            return result;
        }

        //public async Task<GetGradesResponse> GetStudentGradesAsync(AddStudentRequest payload)
        //{
        //    var students = await studentsServices.GetStudentByNameAsync(payload);
        //    if (students == null)
        //    {
        //        throw new Exception($"Student not found.");
        //    }
        //    var grades = await gradesRepository.GetAllAsync();
        //    var result = new GetGradesResponse();
        //    result.Grades = grades.Where(g => g.StudentId == payload.StudentId).Select(
        //        g => new GradeDto
        //        {
        //            Id = g.Id,
        //            StudentId = g.StudentId,
        //            Subject = g.Subject,
        //            Score = g.Score,
        //        }).ToList();
        //    return result;
        //}
    }
}
