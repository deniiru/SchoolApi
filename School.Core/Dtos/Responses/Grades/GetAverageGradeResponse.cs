using School.Core.Dtos.Common.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Responses.Grades
{
    public class GetAverageGradeResponse
    {
        public List<AverageGrade> AverageGrades { get; set; } = new List<AverageGrade>();
    }
}
