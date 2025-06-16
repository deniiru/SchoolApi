using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Delete;
using School.Core.Dtos.Requests.Subjects;
using School.Core.Services;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("Subject")]
    public class SubjectController(SubjectsServices subjectsServices) : Controller
    {
        [HttpPost("Add-subject")]
        public async Task<IActionResult> AddSubject([FromBody] AddSubjectRequest payload)
        {
            await subjectsServices.AddSubjectAsync(payload);
            return Ok();
        }

        [HttpDelete("delete-subject")]
        public async Task<IActionResult> DeleteSubject(DeletePayload payload)
        {
            try
            {
                await subjectsServices.DeleteSubjectAsync(payload);
                return Ok($"Student removed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("get-subject-mean")]
        public async Task<IActionResult> GetSubjectMean(GetSubjectMeanRequest payload)
        {
            try
            {
                var mean = await subjectsServices.GetSubjectMean(payload);
                return Ok(mean);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
