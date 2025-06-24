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

        #region getters 
        [Authorize(Roles = "Admin")]
        [HttpGet("get-students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentsServices.GetAllStudentsAsync();
            return Ok(students);
        }


        [Authorize(Roles = "Admin")]
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

        #endregion

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
        public async Task<IActionResult> UpdateStudentDetails([FromRoute] int id, [FromBody] UpdateStudentRequest payload)
        {
                await studentsServices.UpdateStudentAsync(id, payload);
                return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}/update-group")]
        public async Task<IActionResult> UpdateStudentGroup([FromRoute] int id, [FromBody] UpdateStudentGroupRequest payload)
        {
            await studentsServices.UpdateStundentGroupAsync(id, payload);
            return Ok();
        }
        #endregion


        [HttpPost("end-of-year-average-grade")]
        public async Task<IActionResult> GetStudentFinalGrade([FromQuery] int idStudent)
        {
            var grades = await studentsServices.GetStudentFinalGradeAsync(idStudent);
            return Ok(grades);

        }

        [HttpPost("{idStudent}/subjects-grade")]
        public async Task<IActionResult> GetStudentGradesPerSubjects([FromRoute] int idStudent)
        {

            var grades = await studentsServices.GetStudentFinalGradesAsync(idStudent);
            return Ok(grades);

        }
    }

}
