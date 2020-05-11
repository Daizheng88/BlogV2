using System;

namespace Blog.Contract.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RunAttribute : Attribute
    {
        /// <summary>
        /// 指定运行方法，仅能为静态方法
        /// </summary>
        public string Method { get; set; }
    }
}
