using Blog.Contract.Injections;
using Blog.Core.Repositories.Topic;
using Blog.Core.Repositories.Topic.Inputs;
using Blog.Infrastructure.Ado;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class TopicLikeRepository : ITopicLikeRepository
    {
        public string Table { get { return "Blog_TopicLikes"; } }

        public IDbHelper DbHelper { get; set; }

        public void Delete(TopicLikeInput entity)
        {
            entity.IsDeleted = 1;

            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "IsDeleted", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void Insert(TopicLikeInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsInsert(entity, "Id", "Creator", "CreateTime", "IsDeleted", "TopicId", "UserId")
            );
        }
    }
}
