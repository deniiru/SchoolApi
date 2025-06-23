using School.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Dtos
{
    public class StudentGradesFilteringDto
    {
       
        public YearEnum Year { get; set; }

        public string? Subject { get; set; }

        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 15;
    }
}
