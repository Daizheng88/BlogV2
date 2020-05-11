using System;
using System.Collections.Generic;

namespace Blog.Infrastructure.Ado
{
    public interface IDbHelper : IDisposable
    {
        public int SaveChanges();

        public void Execute(string sql, object parameter = null);

        public void Execute(string sql, Dictionary<string, object> parameter = null);
    }
}
