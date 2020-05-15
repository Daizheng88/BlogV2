using Blog.Core.Repositories.Comment.Inputs;

namespace Blog.Core.Repositories.Comment
{
    /// <summary>
    /// 评论仓储
    /// </summary>
    public interface ICommentRepository : IBaseRepository<CommentInput>
    {
        void UpdateLikes(CommentInput entity);
    }
}
