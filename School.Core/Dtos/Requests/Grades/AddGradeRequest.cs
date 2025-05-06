using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Requests.Grades
{
    public class AddGradeRequest
    {
        public string Subject { get; set; }
        public double Score { get; set; }
        public int StudentId { get; set; }

    }
}
