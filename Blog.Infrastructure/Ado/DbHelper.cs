using Blog.Contract.Injections;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Infrastructure.Ado
{
    [Scope]
    public class DbHelper : IDbHelper
    {
        public DbHelper()
        {
            this.Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            this.Init();
        }

        public DbHelper(IConfiguration config)
        {
            this.Config = config;
            this.Init();
        }

        private void Init()
        {
            string blogString = this.Config.GetConnectionString("Blog");
            this.Connection = new SqlConnection(blogString);
        }

        public IConfiguration Config { get; private set; }

        public SqlConnection Connection { get; private set; }

        // 命令队列
        private Queue<SqlCommand> Commands { get; set; } = new Queue<SqlCommand>();

        // 将命令加入队列
        public void Execute(string sql, object parameter = null)
        {
            SqlCommand command = SqlParser.Parse(sql, parameter);
            command.Connection = this.Connection;
            this.Commands.Enqueue(command);
        }

        // 将命令加入队列
        public void Execute(string sql, Dictionary<string, object> parameter = null)
        {
            SqlCommand command = SqlParser.Parse(sql, parameter);
            command.Connection = this.Connection;
            this.Commands.Enqueue(command);
        }

        // 提交事务
        public int SaveChanges()
        {
            if (this.Commands.Count == 0)
            {
                return 0;
            }

            try
            {
                this.Connection.Open();

                int affected = 0;
                using (SqlTransaction transaction = this.Connection.BeginTransaction())
                {
                    SqlCommand command;

                    try
                    {
                        while ((command = Commands.Dequeue()) != null)
                        {
                            command.Transaction = transaction;
                            affected += command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return affected;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            finally
            {
                this.Connection.Close();
            }
        }

        public void Dispose()
        {
            this.Commands.Clear();
            this.Connection.Dispose();

            this.Commands = null;
            this.Connection = null;
        }
    }
}
