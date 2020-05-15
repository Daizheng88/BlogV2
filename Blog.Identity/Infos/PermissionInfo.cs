using System;
using System.Collections.Generic;

namespace Blog.Identity.Infos
{
    public class PermissionInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<PermissionInfo> SubPermissions { get; set; }
    }
}
