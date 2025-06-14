using Microsoft.AspNetCore.Mvc;
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
    }
}
