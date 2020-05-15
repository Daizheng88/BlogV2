using Blog.Contract.Injections;
using Blog.Core.Repositories.User;
using Blog.Core.Repositories.User.Inputs;
using Blog.Infrastructure.Ado;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class UserRepository : IUserRepository
    {
        private string Table { get { return "Sys_Users"; } }

        public IDbHelper DbHelper { get; set; }

        public void Delete(UserInput entity)
        {
            entity.IsDeleted = 1;
            
            this.DbHelper.Execute(this.Table, proc => 
                proc.AsUpdate(entity, "IsDeleted", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void Insert(UserInput entity)
        {
            this.DbHelper.Execute(this.Table, proc => 
                proc.AsInsert(entity, "Id", "Creator", "CreateTime", "IsDeleted", "EMail", "Password", "Name")
            );
        }

        public void UpdateLoginInfo(UserInput entity)
        {
            this.DbHelper.Execute(this.Table, proc => 
                proc.AsUpdate(entity, "LoginIP", "LastLoginTime")
                    .Where("Id", entity.Id)
            );
        }

        public void UpdateName(UserInput entity)
        {
            this.DbHelper.Execute(this.Table, proc => 
                proc.AsUpdate(entity, "Name", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }

        public void UpdatePassword(UserInput entity)
        {
            this.DbHelper.Execute(this.Table, proc => 
                proc.AsUpdate(entity, "Password", "Modifier", "ModifyTime")
                    .Where("Id", entity.Id)
            );
        }
    }
}
