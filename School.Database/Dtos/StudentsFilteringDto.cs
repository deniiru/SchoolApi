using School.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Dtos
{
    public class StudentsFilteringDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Major { get; set; }

        public string? Group { get; set; }

        public YearEnum Year { get; set; }

        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 15;
    }
}
