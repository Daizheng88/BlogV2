using Blog.Contract.Infrastructure;
using Blog.Contract.Injections;
using Blog.Core.Repositories.User;
using Blog.Core.Repositories.User.Inputs;
using Blog.Infrastructure.Ado;
using System.Text;

namespace Blog.Infrastructure.Core
{
    [Scope]
    public class UserRepository : IUserRepository
    {
        public IDbHelper DbHelper { get; set; }

        public void Delete(UserInput entity)
        {
            string sql = new StringBuilder()
                .AppendFormat("Update Sys_Users Set")
                .AppendFormat(" IsDeleted = 1, Modifier = $Modifier, ModifyTime = $ModifyTime ")
                .AppendFormat("Where Id = $Id ")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }

        public void Insert(UserInput entity)
        {
            string sql = new StringBuilder()
                .AppendFormat("Insert Sys_Users (")
                .AppendFormat(" Id, Creator, CreateTime, IsDeleted, EMail, Password, Name, Signature ")
                .AppendFormat(") Values (")
                .AppendFormat(" $Id, $Creator, $CreateTime, $IsDeleted, @EMail, @Password, @Name, @Signature ")
                .AppendFormat(")")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }

        public void UpdateLoginInfo(UserInput entity)
        {
            string sql = new StringBuilder()
                .AppendFormat("Update Sys_Users Set")
                .AppendFormat(" LoginIp = @LoginIp, LastLoginTime = @LastLoginTime ")
                .AppendFormat("Where Id = $Id")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }

        public void UpdateName(UserInput entity)
        {
            string sql = new StringBuilder()
                .AppendFormat("Update Sys_Users Set")
                .AppendFormat(" Name = @Name, Modifier = $Modifier, ModifyTime = $ModifyTime ")
                .AppendFormat("Where Id = $Id")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }

        public void UpdatePassword(UserInput entity)
        {
            string sql = new StringBuilder()
                .AppendFormat("Update Sys_Users Set")
                .AppendFormat(" Password = @Password, Modifier = $Modifier, ModifyTime = $ModifyTime ")
                .AppendFormat("Where Id = $Id")
                .ToString()
                ;

            this.DbHelper.Execute(sql, entity);
        }
    }
}
