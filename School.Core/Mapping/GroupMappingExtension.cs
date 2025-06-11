using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using School.Core.Dtos.Requests.Groups;
using School.Database.Entities;

namespace School.Core.Mapping
{
    public static class GroupMappingExtension
    {
        public static Group ToEntity (this AddGroupRequest payload)
        {
            var group = new Group
            {
                Name = payload.GroupName,
                An = payload.Year,
                MajorId = payload.MajorId,
            };
            group.CreatedAt = DateTime.UtcNow;
            return group;
        }
    }
}
