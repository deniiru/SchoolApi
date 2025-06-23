using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Responses.Auth
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Token {  get; set; }
    }
}
