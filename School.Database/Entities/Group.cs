using School.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public YearEnum An { get; set; }

        public int MajorId { get; set; }
        public Major Major { get; set; }

        public ICollection<Student> Studentii { get; set; }
    }

}
