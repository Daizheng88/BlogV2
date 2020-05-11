using Blog.Contract.Injections;
using Blog.Core.UnitOfWork;
using System;

namespace Blog.Infrastructure.Ado
{
    [Scope]
    public class UnitOfWork : IUnitOfWork
    {
        public IDbHelper DbHelper { get; set; }

        public ExecutingProcess SaveChanges()
        {
            try
            {
                return new ExecutingProcess(true, this.DbHelper.SaveChanges());
            } 
            catch (Exception ex)
            {
                return new ExecutingProcess(false, 0, ex);
            }
        }
    }
}
