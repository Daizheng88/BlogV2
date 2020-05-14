using System;

namespace Blog.Core.Repositories.Comment.Inputs
{
    public class CommentLikes : Entity
    {
        public Guid UserId { get; set; }

        public Guid CommentId { get; set; }
    }
}
