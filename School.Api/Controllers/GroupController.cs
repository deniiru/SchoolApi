using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Requests.Students;
using School.Core.Dtos.Requests.Groups;
using School.Core.Services;
using School.Core.Dtos.Delete;
using School.Infrastructure.Exceptions;

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

        [HttpPatch("advance-groups")]
        public async Task<IActionResult> AdvanceAllGroups()
        {
            try
            {
                await groupServices.AdvanceAllGroupsAsync();
                return Ok($"Groups advanced with one year successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPost("{groupId}/students")]
        public async Task<IActionResult> GetGroupStundent([FromRoute] int groupId)
        {
            try
            {
                var students = await groupServices.GetGroupStudentsAsync(groupId);
                return Ok(students);
            }
            catch (WrongInputException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-groups")]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await groupServices.GetAllAsync();
            return Ok(groups);
        }
    }
}
