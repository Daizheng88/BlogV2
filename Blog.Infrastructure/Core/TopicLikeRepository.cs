using Blog.Contract.Injections;
using Blog.Core.Repositories.Topic;
using Blog.Core.Repositories.Topic.Inputs;
using Blog.Infrastructure.Ado;
using System.Text;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class TopicLikeRepository : ITopicLikesRepository
    {
        public IDbHelper DbHelper { get; set; }

        public void Delete(TopicLikeInput entity)
        {
            string sql = new StringBuilder()
                .AppendFormat("Update Blog_TopicLikes Set")
                .AppendFormat(" IsDeleted = 1, Modifier = $Modifier, ModifyTime = $ModifyTime ")
                .AppendFormat("Where TopicId = $TopicId And UserId = $UserId")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }

        public void Insert(TopicLikeInput entity)
        {
            string sql = new StringBuilder()
                .AppendFormat("Insert Blog_TopicLikes (")
                .AppendFormat(" Id, Creator, CreateTime, IsDeleted, TopicId, UserId ")
                .AppendFormat(") Values (")
                .AppendFormat(" $Id, $Creator, $CreateTime, $IsDeleted, $TopicId, $UserId ")
                .AppendFormat(")")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }
    }
}
