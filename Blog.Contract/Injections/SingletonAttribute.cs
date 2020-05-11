using System;

namespace Blog.Contract.Injections
{
    /// <summary>
    /// 单例注入
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class SingletonAttribute : Attribute, IInjectable
    {
        public Type Target { get; set; }

        public int Range { get; set; } = 1;
    }
}
