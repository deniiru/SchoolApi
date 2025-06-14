using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Database.Enums;

namespace School.Database.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public YearEnum Year { get; set; }

        public int MajorId { get; set; }
        public Major Major { get; set; }

        public List<Grade> Grades { get; set; }
    }
}
