using System;

namespace Blog.Contract.Injections
{
    /// <summary>
    /// 简单注入
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class TransientAttribute : Attribute, IInjectable
    {
        public Type Target { get; set; }

        public int Range { get; set; } = 1;
    }
}
