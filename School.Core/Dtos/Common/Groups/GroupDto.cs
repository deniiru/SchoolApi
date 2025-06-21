using School.Core.Dtos.Common.Major;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Common.Groups
{
    public class GroupDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MajorId { get; set; }

        public MajorDto Major{ get; set;}
    }
}
