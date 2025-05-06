using School.Core.Dtos.Common.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Common.Students
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public List<GradeDto> Grades { get; set; } = new List<GradeDto>();

    }
}
