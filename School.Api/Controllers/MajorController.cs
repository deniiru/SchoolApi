using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Requests.Majors;
using School.Core.Services;
using School.Core.Dtos.Delete;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("Group")]
    public class MajorController(MajorsServices majorsServices) : Controller
    {
        [HttpPost("Add-major")]
        public async Task<IActionResult> AddMajor([FromBody] AddMajorRequest payload)
        {
            await majorsServices.AddMajorAsync(payload);
            return Ok();
        }

        [HttpDelete("delete-major")]
        public async Task<IActionResult> DeleteMajor(DeletePayload payload)
        {
            try
            {
                await majorsServices.DeleteMajorAsync(payload);
                return Ok($"Major removed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}
