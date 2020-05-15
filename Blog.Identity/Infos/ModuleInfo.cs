using System;
using System.Collections.Generic;

namespace Blog.Identity.Infos
{
    /// <summary>
    /// 模块信息
    /// </summary>
    public class ModuleInfo
    {
        /// <summary>
        /// 标识
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Url 地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 模块信息
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 子模块集
        /// </summary>
        public List<ModuleInfo> SubModules { get; set; }
    }
}
