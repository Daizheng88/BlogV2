using Blog.Contract.Injections;
using Blog.Core.Repositories.Comment.Inputs;
using Blog.Core.Repositories.Comments;
using Blog.Infrastructure.Ado;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class CommentLikeRepository : ICommentLikeRepository
    {
        public string Table { get { return "Blog_CommentLikes"; } }

        public IDbHelper DbHelper { get; set; }

        public void Delete(CommentLikes entity)
        {
            entity.IsDeleted = 1;

            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "IsDeleted", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void Insert(CommentLikes entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsInsert(entity, "Id", "Creator", "CreateTime", "IsDeleted", "CommentId", "UserId")
            );
        }
    }
}
