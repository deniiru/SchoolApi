using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Responses.Students
{
    public class GetStudentsWhoFailedInSubjectResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Mean { get; set; }

        public GetStudentsWhoFailedInSubjectResponse()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Mean = 0.0;
        }

        public GetStudentsWhoFailedInSubjectResponse(string firstName, string lastName, double mean)
        {
            FirstName = firstName;
            LastName = lastName;
            Mean = mean;
        }
    }
}
