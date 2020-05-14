using Blog.Core.Repositories.Topic.Inputs;

namespace Blog.Core.Repositories.Topic
{
    /// <summary>
    /// 主题仓储
    /// </summary>
    public interface ITopicRepository : IBaseRepository<TopicInput>
    {
        void Update(TopicInput entity);

        void UpdateLikes(TopicInput entity);
    }
}
