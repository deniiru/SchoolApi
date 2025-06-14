using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Requests.Students;
using School.Core.Services;
using System.Runtime.CompilerServices;
using School.Core.Dtos.Delete;

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

        [HttpDelete("delete-student")]
        public async Task<IActionResult> DeleteStudent(DeletePayload payload)
        {
            try
            {
                await studentsServices.DeleteStudentAsync(payload);
                return Ok($"Student removed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        //****************************************
        [HttpGet("get-students-with-grades")]
        public async Task<IActionResult> GetStudentsWithGrades()
        {
            var students = await studentsServices.GetStudentsWithGradesAsync();
            return Ok(students);
        }

        [HttpPost("get-fillter-students-with-grades")]
        public async Task<IActionResult> GetSFiltertudentsWithGrades(GetFilterdStudentsRequest payload)
        {
            var students = await studentsServices.GetFilteredStudentsWithGradesAsync(payload);
            return Ok(students);
        }
    }

}
