using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Requests.Majors;
using School.Core.Services;

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

    }
}
