using School.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Requests.Subjects
{
    public class AddSubjectRequest
    {
        public string? Name { get; set; }
        public int TeacherId { get; set; }

        public YearEnum Year { get; set; }

        public int MajorId { get; set; }

    }
}
