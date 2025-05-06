using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Grade: BaseEntity
    {
        public string? Subject { get; set; }
        public double Score { get; set; }

        // Foreign key
        public int StudentId { get; set; }

        // Navigation property
        public Student Student { get; set; }
    }
}
