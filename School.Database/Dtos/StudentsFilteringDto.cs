using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Dtos
{
    public class StudentsFilteringDto
    {
        public string SearchValue { get; set; }
        public DateRangeDto DateRange { get; set; }

        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 15;
    }
}
