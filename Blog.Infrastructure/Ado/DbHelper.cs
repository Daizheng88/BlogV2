using Blog.Contract.Infrastructure.Extensions;
using Blog.Contract.Injections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Blog.Infrastructure.Ado
{
    [Scope]
    public class DbHelper : IDbHelper
    {
        public DbHelper(IConfiguration config, IHostingEnvironment environment)
        {
            this.Config = config;

            // 取得连接字符串 (DES 解密)
            this.Connection = environment.IsDevelopment()
                ? new SqlConnection(this.Config.GetConnectionString("Blog_Dev"))
                : new SqlConnection(this.Config.GetConnectionString("Blog").DESDecrypt());

            // 取得工厂对象
            this.Factory = new QueryFactory(this.Connection, new SqlServerCompiler());

            // 取得队列
            this.Queries = new Queue<Query>();
        }

        public IConfiguration Config { get; }

        public SqlConnection Connection { get; set; }

        public QueryFactory Factory { get; set; }

        public Queue<Query> Queries { get; set; }

        public void Dispose()
        {
            this.Connection.Dispose();
            this.Connection = null;
        }

        public void Execute(Func<Query, Query> callback)
        {
             Queries.Enqueue(callback(this.Factory.Query()));
        }

        public void Execute(string tablename, Func<Query, Query> callback)
        {
            Queries.Enqueue(callback(this.Factory.Query(tablename)));
        }

        public int SaveChanges()
        {
            int affected = 0;
            using (IDbTransaction transaction = this.Connection.BeginTransaction())
            {
                try
                {
                    Query item;
                    while ((item = Queries.Dequeue()) != null)
                    {
                        // 执行Sql
                        affected += this.Factory.Execute(item, transaction, CommandType.Text);
                    }

                    // 提交事务
                    transaction.Commit();

                    return affected;
                }
                catch
                {
                    // 回滚事务
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
