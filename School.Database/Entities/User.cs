using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class User : BaseEntity
    {
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        // Extend with login details as needed
        public string Email {  get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
    }
}
