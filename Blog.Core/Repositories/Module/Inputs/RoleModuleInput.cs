using System;

namespace Blog.Core.Repositories.Module.Inputs
{
    public class RoleModuleInput : Entity
    {
        public Guid UserId { get; set; }

        public Guid ModuleId { get; set; }
    }
}
