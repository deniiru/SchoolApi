using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Delete;
using School.Core.Dtos.Requests.Students;
using School.Core.Dtos.Requests.Teachers;
using School.Core.Services;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("Teachers")]
    public class TeacherController(TeachersServices teachersServices) : Controller
    {

        [HttpPost("Add-teacher")]
        public async Task<IActionResult> AddTeacher([FromBody] AddTeacherRequest payload)
        {
            await teachersServices.AddTeacherAsync(payload);
            return Ok();
        }

        [HttpDelete("delete-teacher")]
        public async Task<IActionResult> DeleteTeacher(DeletePayload payload)
        {
            try
            {
                await teachersServices.DeleteTeacherAsync(payload);
                return Ok($"Student removed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("get-teachers-with-subjects")]
        public async Task<IActionResult> GetAllTeacherWithSubjects()
        {
            var teachers = await teachersServices.GetAllWithSubjectsAsync();
            return Ok(teachers);
        }

    }
}
