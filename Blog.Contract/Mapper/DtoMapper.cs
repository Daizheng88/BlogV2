using System;
using System.Collections.Generic;
using System.Reflection;

namespace Blog.Contract.Mapper
{
    /// <summary>
    /// 数据映射子项
    /// </summary>
    public class DtoMapper
    {
        public DtoMapper()
        {
            // 初始化字典
            Dict = new Dictionary<Type, MethodInfo>();
        }

        /// <summary>
        /// 实例对象
        /// </summary>
        public object Object { get; set; }

        /// <summary>
        /// 关系字典
        /// </summary>
        public Dictionary<Type, MethodInfo> Dict { get; set; }
    }
}