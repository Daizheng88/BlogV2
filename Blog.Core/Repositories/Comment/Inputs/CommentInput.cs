//---------------------------------------------------
//-- Author:     DAIZHENG
//-- CreateDate: 2020/5/11
//-- Name:       评论
//-----------------------------------------------------------
using System;

namespace Blog.Core.Repositories.Comment.Inputs
{
    public class CommentInput : Entity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 话题ID
        /// </summary>
        public Guid TopicId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 喜欢人数
        /// </summary>
        public int Likes { get; set; }
    }
}
