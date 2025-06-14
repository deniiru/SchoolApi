using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Requests.Teachers
{
    public class AddTeacherRequest
    {
        public string? FirstName {  get; set; }

        public string? LastName { get; set; }
    }
}
