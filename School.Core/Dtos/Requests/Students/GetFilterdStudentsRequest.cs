using School.Database.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Requests.Students
{
    public class GetFilterdStudentsRequest
    {
        public StudentsFilteringDto Filters { get; set; }
        public StudentsSortingDto SortingOption { get; set; }
    }
}
