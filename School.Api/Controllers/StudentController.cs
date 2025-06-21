using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Requests.Students;
using School.Core.Services;
using School.Core.Dtos.Delete;
using School.Core.Dtos.Responses.Students;
using System.ComponentModel.DataAnnotations;
using School.Infrastructure.Exceptions;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController(StudentsServices studentsServices) : Controller
    {
        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequest payload)
        {
            await studentsServices.AddStudentAsync(payload);
            return Ok($"Student {payload.FirstName} added successfully.");
        }

        [HttpGet("get-students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentsServices.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpDelete("delete-student")]
        public async Task<IActionResult> DeleteStudent(DeletePayload payload)
        {
            try
            {
                await studentsServices.DeleteStudentAsync(payload);
                return Ok($"Student removed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        #region update 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentDetails(int id, [FromBody] UpdateStudentRequest payload)
        {
            try
            {
                await studentsServices.UpdateStudentAsync(id, payload);
                return Ok();
            }
            catch (WrongInputException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/group")]
        public async Task<IActionResult> UpdateStudentGroup(int id, [FromBody] UpdateStudentGroupRequest payload)
        {
            try
            {
                await studentsServices.UpdateStundentGroupAsync(id, payload);
                return Ok();
            }
            catch (WrongInputException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        //****************************************
        [HttpGet("get-students-with-grades")]
        public async Task<IActionResult> GetStudentsWithGrades()
        {
            var students = await studentsServices.GetStudentsWithGradesAsync();
            return Ok(students);
        }

        //[HttpPost("get-fillter-students-with-grades")]
        //public async Task<IActionResult> GetSFiltertudentsWithGrades(GetFilterdStudentsRequest payload)
        //{
        //    var students = await studentsServices.GetFilteredStudentsWithGradesAsync(payload);
        //    return Ok(students);
        //}

        [HttpPost("get-students-filtered")]
        public async Task<IActionResult> GetStudentsFiltered(GetFilterdStudentsRequest payload)
        {
            var students = await studentsServices.GetFilterStudentsAsync(payload);
            return Ok(students);
        }

        [HttpPost("get-student-mean-in-subject")]
        public async Task<IActionResult> GetStudentMeanInSubject(GetStudentMeanInSubjectRequest payload)
        {
            var mean = await studentsServices.GetStudentMeanInSubjectAsync(payload);
            return Ok(mean);
        }

        [HttpPost("get-failures-in-subject")]//i know i am mean
        public async Task<IActionResult> GetStudentsWhoFailedInSubject(GetStudentsWhoFailedInSubjectRequest payload)
        {
            var students = await studentsServices.GetAllStudentsWhoFailedInSubjectAsync(payload);
            return Ok(students);
        }

        [HttpPost("{idStudent}/grades")]
        public async Task<IActionResult> GetStudentGrades([FromRoute] int idStudent, [FromBody] GetFilterdStudentGradesRequest payload)
        {
            var grades = await studentsServices.GetStudentGradesAsync(idStudent, payload);
            return Ok(grades);
        }
    }

}
