using Microsoft.AspNetCore.Mvc;
using School.Core.Services;
using School.Core.Dtos.Requests.Grades;
using School.Core.Dtos.Requests.Students;
using School.Database.Context;
using School.Core.Dtos.Common.Grades;
using School.Core.Dtos.Delete;
using Microsoft.AspNetCore.Authorization;

namespace School.Api.Controllers
{
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> DeleteGrade(DeletePayload payload)
        {
            try
            {
                await gradesServices.DeleteGradeAsync(payload);
                return Ok($"Grade removed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateGradeRequest request)
        {

            request.Id = id;
            await gradesServices.UpdateGradeAsync(request);
            return Ok($"Grade added successfully.");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGradeById (int id)
        {
            var grade = await gradesServices.GetByIdAsync(id);
            return Ok(grade);
        }

     
        [HttpPost("get-grades")]
        public async Task<IActionResult> GetGrades([FromBody]GetFilteredGradesRequest payload)
        {
            try
            {
                var grades = await gradesServices.GetAllGradesAsync(payload);
                return Ok(grades);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }

}

// - elev - getAllstudentid
// - profesor - by id, getAll(cu filtre)  