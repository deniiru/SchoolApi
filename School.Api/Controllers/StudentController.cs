using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Requests.Students;
using School.Core.Services;
using School.Core.Dtos.Requests.Students;
using System.Runtime.CompilerServices;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController(StudentsServices studentsServices ) : Controller
    {
        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequest payload)
        {
            await studentsServices.AddStudentAsync(payload);
            return Ok($"Student {payload.FirstName} added successfully.");
        }

        [HttpGet("get-students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentsServices.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("get-students-with-grades")]
        public async Task<IActionResult> GetStudentsWithGrades()
        {
            var students = await studentsServices.GetStudentsWithGradesAsync();
            return Ok(students);
        }

    }

}
