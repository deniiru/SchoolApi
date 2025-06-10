using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Grade: BaseEntity
    {
        public double Score { get; set; }

        // Foreign key
        public int SubjectId { get; set; }
        public int StudentId { get; set; }

        // Navigation property
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
