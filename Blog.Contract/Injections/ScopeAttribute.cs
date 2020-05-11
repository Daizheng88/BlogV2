using System;

namespace Blog.Contract.Injections
{
    /// <summary>
    /// 线程内注入
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class ScopeAttribute : Attribute, IInjectable
    {
        public Type Target { get; set; }

        public int Range { get; set; } = 1;
    }
}
