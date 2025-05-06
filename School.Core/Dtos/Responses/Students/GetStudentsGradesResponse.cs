using School.Core.Dtos.Common.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Responses.Students
{
    public class GetStudentsGradesResponse : GetStudentsResponse
    {
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
