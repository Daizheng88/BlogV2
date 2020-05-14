using Blog.Core.Repositories.Topic.Inputs;

namespace Blog.Core.Repositories.Topic
{
    /// <summary>
    /// 主题点赞仓储
    /// </summary>
    public interface ITopicLikeRepository : IBaseRepository<TopicLikeInput>
    {
    }
}
