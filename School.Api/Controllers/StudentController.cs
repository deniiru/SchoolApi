using Microsoft.AspNetCore.Mvc;
using School.Core.Dtos.Requests.Students;
using School.Core.Services;
using School.Core.Dtos.Delete;
using School.Core.Dtos.Responses.Students;
using System.ComponentModel.DataAnnotations;
using School.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace School.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("students")]
    public class StudentController(StudentsServices studentsServices) : Controller
    {
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpPost("get-students-who-failed-in-subject")]
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

        [HttpPost("end-of-year-average-grade")]
        public async Task<IActionResult> GetStudentFinalGrade([FromQuery] int idStudent)
        {
            try
            {
                var grades = await studentsServices.GetStudentFinalGradeAsync(idStudent);
                return Ok(grades);
            }
            catch (WrongInputException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ResourceMissingException ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost("{idStudent}/subjects-grade")]
        public async Task<IActionResult> GetStudentGradesPerSubjects([FromRoute] int idStudent)
        {
            try
            {
                var grades = await studentsServices.GetStudentFinalGradesAsync(idStudent);
                return Ok(grades);
            }
            catch (WrongInputException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ResourceMissingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
