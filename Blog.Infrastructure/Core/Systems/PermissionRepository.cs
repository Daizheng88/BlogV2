using Blog.Contract.Injections;
using Blog.Core.Repositories.Permission;
using Blog.Core.Repositories.Permission.Inputs;
using Blog.Infrastructure.Ado;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class PermissionRepository : IPermissionRepository
    {
        public string Table { get { return "Sys_Permissions"; } }

        public IDbHelper DbHelper { get; set; }

        public void Delete(PermissionInput entity)
        {
            entity.IsDeleted = 1;

            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "IsDeleted", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void Insert(PermissionInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsInsert(entity, "Id", "Creator", "CreateTime", "IsDeleted", "ParentId", "Name")
            );
        }

        public void Update(PermissionInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "ParentId", "Name", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }
    }
}
