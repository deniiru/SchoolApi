using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Requests.Students;
using School.Core.Dtos.Requests.Groups;
using School.Core.Services;
using School.Core.Dtos.Delete;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("Group")]
    public class GroupController(GroupsServices groupServices) : Controller
    {
        [HttpPost("Add-group")]
        public async Task<IActionResult> AddGroup([FromBody] AddGroupRequest payload)
        {
            await groupServices.AddGroupAsync(payload);
            return Ok();
        }

        [HttpDelete("delete-group")]
        public async Task<IActionResult> DeleteGroup(DeletePayload payload)
        {
            try
            {
                await groupServices.DeleteGroupAsync(payload);
                return Ok($"Group removed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}
