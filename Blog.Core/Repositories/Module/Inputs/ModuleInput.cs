using System;

namespace Blog.Core.Repositories.Module.Inputs
{
    public class ModuleInput : Entity
    {
        /// <summary>
        /// 父级模块
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 目标方式 _blank _self
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 模块图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 模块信息
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int IsVisible { get; set; }

        /// <summary>
        /// 状态 [0 未上线], [1 正常], [2 上锁]
        /// </summary>
        public int Status { get; set; }
    }
}
