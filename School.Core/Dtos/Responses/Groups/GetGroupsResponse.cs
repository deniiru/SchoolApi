using School.Core.Dtos.Common.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Dtos.Responses.Groups
{
    public class GetGroupsResponse
    {
        public List<GroupDto> Groups { get; set; } = new List<GroupDto>();
    }
}
