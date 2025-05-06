using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Student: BaseEntity
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public List<Grade> Grades { get; set; } = new List<Grade>();


    }
}
