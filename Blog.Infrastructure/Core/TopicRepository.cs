using Blog.Contract.Infrastructure.Extensions;
using Blog.Contract.Injections;
using Blog.Core.Repositories.Topic;
using Blog.Core.Repositories.Topic.Inputs;
using Blog.Infrastructure.Ado;
using System.Text;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class TopicRepository : ITopicRepository
    {
        public IDbHelper DbHelper { get; set; }

        public void Delete(TopicInput entity)
        {
            string sql = new StringBuilder()
                .AppendFormat("Update Blog_Topics Set")
                .AppendFormat(" IsDeleted = 1, Modifier = $Modifier, ModifyTime = $ModifyTime ")
                .AppendFormat("Where Id = $Id ")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }

        public void Insert(TopicInput entity)
        {
            string sql = new StringBuilder()
                .AppendFormat("Insert Blog_Topics (")
                .AppendFormat(" Id, Creator, CreateTime, TypeId, Title, Content, Comments, Likes ")
                .AppendFormat(") Values (")
                .AppendFormat(" $Id, $Creator, $CreateTime, $TypeId, @Title, @Content, $Comments, $Likes ")
                .AppendFormat(")")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }

        public void Update(TopicInput entity)
        {
            if (entity.Title.NoCharacters() && entity.Content.NoCharacters())
            {
                return;
            }

            string sql = new StringBuilder()
                .AppendFormat("Update Blog_Topics Set")
                .AppendFormatIf(entity.Title.HasCharacters(), " Title = @Title,")
                .AppendFormatIf(entity.Content.HasCharacters(), " Content = @Content ")
                .AppendFormat("Where Id = $Id")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }
    }
}
