using School.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Common.Grades
{
    public class AverageGrade
    {
        public string? Subject { get; set; }

        public double Score { get; set; }
    }
}
