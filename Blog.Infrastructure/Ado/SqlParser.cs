using Blog.Contract.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Blog.Infrastructure.Ado
{
    public static class SqlParser
    {
        /// <summary>
        /// 将值转为可被数据库识别类型
        /// </summary>
        private static string ValueParse(object value)
        {
            if (value == null)
            {
                return "NULL";
            }
            else if (value is string)
            {
                return $"N'{((string)value).Replace("'", "''")}'";
            }
            else if (value is Guid)
            {
                return $"'{value}'";
            }
            else if (value is DateTime)
            {
                return $"'{value:yyyy-MM-dd HH:mm:ss}'";
            }
            return value.ToString();
        }

        /// <summary>
        /// 将 Sql 进行封装
        /// </summary>
        public static SqlCommand Parse<TEntity>(string sql, TEntity parameter)
        {
            if (parameter == null)
            {
                return new SqlCommand(sql);
            }

            // 参数
            Dictionary<string, object> arg = new Dictionary<string, object>();

            // 取得属性值
            parameter.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty)
                .Each(prop =>
                {
                    arg[prop.Name] = prop.GetValue(parameter, null);
                })
                ;

            return Parse(sql, arg);
        }

        /// <summary>
        /// 将 Sql 进行封装
        /// </summary>
        public static SqlCommand Parse(string sql, Dictionary<string, object> parameter)
        {
            if (parameter == null)
            {
                return new SqlCommand(sql);
            }

            // 待返回对象
            SqlCommand sqlCommand = new SqlCommand();
            List<SqlParameter> parameters = new List<SqlParameter>();

            // 将Sql载入 SBuilder 方便进行处理
            StringBuilder xSqlBuilder = new StringBuilder()
                .Append(sql)
                ;

            // 匹配后从结尾处开始替换，保持索引不会因为字符串被替换而改变
            foreach (Match match in Regex.Matches(sql, @"[(=,\s](?<cmd>[$@]\w{1,})").Reverse())
            {
                Group cmdGroup = match.Groups["cmd"];

                string prop = cmdGroup.Value.Substring(1);
                object value;
                if (!parameter.TryGetValue(prop, out value))
                {
                    value = null;
                }

                if (cmdGroup.Value[0] == '$')
                {
                    xSqlBuilder.Replace(prop, ValueParse(value), cmdGroup.Index, 1);
                }
                else
                {
                    if (!parameters.Any(i => i.ParameterName.Equals(prop)))
                    {
                        parameters.Add(new SqlParameter(prop, value));
                    }
                }
            }

            sqlCommand.CommandText = xSqlBuilder.ToString();
            sqlCommand.Parameters.AddRange(parameters.ToArray());
            return sqlCommand;
        }
    }
}
