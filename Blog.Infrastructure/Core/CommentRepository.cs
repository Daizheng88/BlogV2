using Blog.Contract.Injections;
using Blog.Core.Repositories.Comment;
using Blog.Core.Repositories.Comment.Inputs;
using Blog.Infrastructure.Ado;
using System;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class CommentRepository : ICommentRepository
    {
        public string Table { get { return "Blog_Comments"; } }
        
        public IDbHelper DbHelper { get; set; }

        public void Delete(CommentInput entity)
        {
            entity.IsDeleted = 1;

            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "IsDeleted", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void Insert(CommentInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsInsert(entity, "Id", "Creator", "CreateTime", "IsDeleted", "Content", "TopicId", "UserId", "Likes")
            );
        }
    }
}
