using Microsoft.AspNetCore.Mvc;
using School.Core.Services;
using School.Core.Dtos.Requests.Grades;
using School.Core.Dtos.Requests.Students;
using School.Database.Context;
using School.Core.Dtos.Common.Grades;

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

        [HttpDelete("delete-grade")]
        public async Task<IActionResult> DeleteGrade(int gradeId)
        {
            try
            {
                await gradesServices.DeleteGradeAsync(gradeId);
                return Ok($"Grade removed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateGradeRequest request)
        {

            request.Id = id;
            await gradesServices.UpdateGradeAsync(request);
            return Ok($"Grade added successfully.");

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

