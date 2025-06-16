using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Requests.Students
{
    public class GetStudentMeanInSubjectRequest
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
