using System;

namespace Blog.Contract.Infrastructure
{
    /// <summary>
    /// 实体
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDeleted { get; set; } = DbBoolean.False;

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid Creator { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public Guid? Modifier { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public string ModifyTime { get; set; }
    }
}
