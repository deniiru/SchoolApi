using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Requests.Auth
{
    public class RegisterRequest
    {
        public int StudentId { get; set; }  
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
