using SqlKata;
using System;

namespace Blog.Infrastructure.Ado
{
    public interface IDbHelper : IDisposable
    {
        public int SaveChanges();

        public void Execute(string tablename, Func<Query, Query> callback);

        public void Execute(Func<Query, Query> callback);
    }
}
