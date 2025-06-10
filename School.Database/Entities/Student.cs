using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Student: BaseEntity
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int GroupId {  get; set; }
        public Group Group { get; set; }

        public List<Grade> Grades { get; set; } = new List<Grade>();


    }
}
