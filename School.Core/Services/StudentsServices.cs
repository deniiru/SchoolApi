using School.Core.Dtos.Common.Grades;
using School.Core.Dtos.Common.Students;
using School.Core.Dtos.Delete;
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
        private readonly GradesRepository gradesRepository;
        private readonly SubjectsRepository subjectRepository;

        public StudentsServices(StudentsRepository studentsRepository, GradesRepository gradesRepository, SubjectsRepository subjectsRepository)
        {
            this.studentsRepository = studentsRepository;
            Console.WriteLine("StudentsServices initialized");
            this.gradesRepository = gradesRepository;
            this.subjectRepository = subjectsRepository;
        }

        public async Task AddStudentAsync(AddStudentRequest payload)
        {
            // find the group iD
            var newStudent = payload.ToEntity();
            newStudent.CreatedAt = DateTime.UtcNow;

            await studentsRepository.AddAsync(newStudent);
            Console.WriteLine($"Student {payload.FirstName} added successfully.");
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

        public async Task DeleteStudentAsync(DeletePayload payload)
        {
            var student = studentsRepository.GetByIdAsync(payload.Id).Result;

            if (student == null)
            {
                throw new Exception($"Student with ID {payload.Id} was not found.");
            }

            var grades = await gradesRepository.GetByStudentIdAsync(student.Id);
            foreach (var grade in grades)
            {
                await gradesRepository.SoftDeleteAsync(grade);
            }

            await studentsRepository.SoftDeleteAsync(student);
        }

        public async Task<double> GetStudentMeanInSubjectAsync(GetStudentMeanInSubjectRequest payload)
        {
            if(await studentsRepository.GetByIdAsync(payload.StudentId) == null)
            {
                throw new Exception($"Student with ID {payload.StudentId} was not found.");
            }

            var grades = await studentsRepository.GetAllGradesForStudentInSubjectAsync(payload.StudentId, payload.SubjectId);

            if(grades.Count == 0)
            {
                throw new Exception($"Student with ID {payload.StudentId} has no grades in subject with ID {payload.SubjectId}.");
            }

            double sum = 0;

            foreach(var grade in grades)
            {
                sum += grade.Score;
            }

            var result = sum / grades.Count();

            return result;
        }

        public async Task<List<GetStudentsWhoFailedInSubjectResponse>> GetAllStudentsWhoFailedInSubjectAsync(GetStudentsWhoFailedInSubjectRequest payload)
        {
            if(await subjectRepository.GetFirstOrDefaultAsync(payload.SubjectId) == null)
            {
                throw new Exception($"Subject with ID {payload.SubjectId} was not found.");
            }

            var students = await studentsRepository.GetAllAsync();
            List<GetStudentsWhoFailedInSubjectResponse> result = [];

            foreach (var student in students)
            {
                var grades = await studentsRepository.GetAllGradesForStudentInSubjectAsync(student.Id, payload.SubjectId);
                if (grades.Count == 0)
                {
                    continue;
                }

                double mean = 0;
                foreach (var grade in grades)
                {
                    mean += grade.Score;
                }

                mean /= grades.Count();

                if(mean < 5)
                {
                    result.Add(new GetStudentsWhoFailedInSubjectResponse(student.FirstName, student.LastName, mean));
                }
            }

            return result;
        }
    }
}
