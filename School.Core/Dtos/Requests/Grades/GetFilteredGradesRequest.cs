using School.Database.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Requests.Grades
{
    public class GetFilteredGradesRequest
    {
        public GradesFilteringDto Filters { get; set; }
        public GradesSortingDto SortingOption { get; set; }
    }
}
