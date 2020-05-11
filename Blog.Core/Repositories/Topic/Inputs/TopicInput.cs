using System;

namespace Blog.Core.Repositories.Topic.Inputs
{
    public class TopicInput : Entity
    {
        /// <summary>
        /// 类型 Id
        /// </summary>
        public Guid TypeId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 评论人数
        /// </summary>
        public int Comments { get; set; }

        /// <summary>
        /// 喜欢人数
        /// </summary>
        public int Likes { get; set; }
    }
}
