using School.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Dtos
{
    public class StudentsSortingDto
    {
        public SortingOrder Order { get; set; }
        public  StudentsSortingCriteria Criterion { get; set; }
    }
}
