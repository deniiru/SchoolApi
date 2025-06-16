using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Responses.Teachers
{
    public class GetTeacherWithSubjectResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        //Thinking if they are necessary
        //public int Year { get; set; }
        //public string Major {  get; set;

        public GetTeacherWithSubjectResponse()
        {
            FirstName = string.Empty; 
            LastName = string.Empty;
            Subject = string.Empty;
        }

        public GetTeacherWithSubjectResponse(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }
    }
}
