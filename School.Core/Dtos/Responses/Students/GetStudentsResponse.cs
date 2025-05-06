using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Core.Dtos.Common.Students;

namespace School.Core.Dtos.Responses.Students
{
    public class GetStudentsResponse
    {
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
