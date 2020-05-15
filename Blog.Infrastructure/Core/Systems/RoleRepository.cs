using Blog.Contract.Injections;
using Blog.Core.Repositories.Role;
using Blog.Core.Repositories.Role.Inputs;
using Blog.Infrastructure.Ado;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class RoleRepository : IRoleRepository
    {
        public string Table { get { return "Sys_Roles"; } }

        public IDbHelper DbHelper { get; set; }

        public void Delete(RoleInput entity)
        {
            entity.IsDeleted = 1;

            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "IsDeleted", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void Insert(RoleInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsInsert(entity, "Id", "Creator", "CreateTime", "IsDeleted", "Name")
            );
        }

        public void Update(RoleInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "Name", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }
    }
}
