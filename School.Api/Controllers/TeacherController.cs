﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
