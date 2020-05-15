using Blog.Contract.Injections;
using Blog.Core.Repositories.Type;
using Blog.Core.Repositories.Type.Inputs;
using Blog.Infrastructure.Ado;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class TypeRepository : ITypeRepository
    {
        public string Table { get { return "Blog_Types"; } }

        public IDbHelper DbHelper { get; set; }

        public void Delete(TypeInput entity)
        {
            entity.IsDeleted = 1;

            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "IsDeleted", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void Insert(TypeInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsInsert(entity, "Id", "Creator", "CreateTime", "IsDeleted", "No", "Name")
            );
        }

        public void Update(TypeInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "No", "Name")
                    .Where("Id", entity.Id)
            );
        }
    }
}
