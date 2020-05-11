using System;

namespace Blog.Core.Repositories.Topic.Inputs
{
    public class TopicLikeInput : Entity
    {
        public Guid UserId { get; set; }

        public Guid TopicId { get; set; }
    }
}
