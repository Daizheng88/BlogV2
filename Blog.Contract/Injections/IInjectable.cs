using System;

namespace Blog.Contract.Injections
{
    /// <summary>
    /// 可被注入的
    /// </summary>
    public interface IInjectable
    {
        /// <summary>
        /// 依赖类型
        /// </summary>
        Type Target { get; set; }
    }
}
