using Blog.Contract.Injections;
using Blog.Core.Repositories.Module;
using Blog.Core.Repositories.Module.Inputs;
using Blog.Infrastructure.Ado;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class ModuleRepository : IModuleRepository
    {
        public string Table { get { return "Sys_Modules"; } }

        public IDbHelper DbHelper { get; set; }

        public void Delete(ModuleInput entity)
        {
            entity.IsDeleted = 1;

            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "IsDeleted", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void Insert(ModuleInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsInsert(entity, "Id", "Creator", "CreateTime", "IsDeleted", "ParentId", "Target", "Icon", "Name", "IsVisible", "Status")
            );
        }

        public void Update(ModuleInput entity)
        {
            this.DbHelper.Execute(this.Table, proc =>
                proc.AsUpdate(entity, "ParentId", "Target", "Icon", "Name", "IsVisible", "Status", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }
    }
}
