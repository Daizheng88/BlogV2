using System;

namespace Blog.Core.Repositories.Permission.Inputs
{
    public class PermissionInput : Entity
    {
        /// <summary>
        /// 父级权限
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 权限信息
        /// </summary>
        public string Name { get; set; }
    }
}
