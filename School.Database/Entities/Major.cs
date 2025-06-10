using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Major : BaseEntity
    {
        public string Name { get; set; }

        public List<Group> Groups { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
