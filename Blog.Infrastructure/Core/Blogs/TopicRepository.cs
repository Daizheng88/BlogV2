using Blog.Contract.Injections;
using Blog.Core.Repositories.Topic;
using Blog.Core.Repositories.Topic.Inputs;
using Blog.Infrastructure.Ado;
using SqlKata;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class TopicRepository : ITopicRepository
    {
        private string Table { get { return "Blog_Topics"; } }

        public IDbHelper DbHelper { get; set; }

        public void Delete(TopicInput entity)
        {
            entity.IsDeleted = 1;

            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "IsDeleted", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void Insert(TopicInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsInsert(entity, "Id", "Creator", "CreateTime", "IsDeleted", "TypeId", "Title", "Content", "Likes", "Comments")
            );
        }

        public void Update(TopicInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "TypeId", "Title", "Content", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void UpdateLikes(TopicInput entity)
        {
            object value = Expressions.UnsafeLiteral($"Likes + {entity.Likes}");

            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(new[] { "Likes" }, new[] { value })
                    .Where("Id", entity.Id)
            );
        }
    }
}
