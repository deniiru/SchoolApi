using Microsoft.AspNetCore.Mvc;
using School.Core.Services;
using School.Core.Dtos.Requests.Grades;
using School.Core.Dtos.Requests.Students;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("grades")]
    public class GradeController(StudentsServices studentsServices, GradesServices gradesServices) : Controller
    {
        [HttpPost("add-grade")]
        public async Task<IActionResult> AddGrade([FromBody] AddGradeRequest payload)
        {
            try
            {
                await gradesServices.AddGradeAsync(payload);
                return Ok($"Grade added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("get-grades")]
        public async Task<IActionResult> GetGrades()
        {
            try
            {
                var grades = await gradesServices.GetAllGradesAsync();
                return Ok(grades);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
        [HttpGet("get-student-grades")]
        public async Task<IActionResult> GetStudentGrades([FromBody] AddStudentRequest payload)
        {
            try
            {
                //var grades = await gradesServices.GetStudentGradesAsync(payload);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }

}

