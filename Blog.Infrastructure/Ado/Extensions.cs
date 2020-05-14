using SqlKata;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Blog.Infrastructure.Ado
{
    public static class Extensions
    {
        public static Query AsInsert(this Query current, object entity, params string[] columns)
        {
            List<PropertyInfo> pis = entity.GetType()
                .GetProperties()
                .Where(i => columns.Contains(i.Name))
                .ToList()
                ;

            return current.AsInsert(pis.Select(i => i.Name), pis.Select(i => i.GetValue(entity)));
        }

        public static Query AsUpdate(this Query current, object entity, params string[] columns)
        {
            List<PropertyInfo> pis = entity.GetType()
                .GetProperties()
                .Where(i => columns.Contains(i.Name))
                .ToList()
                ;

            return current.AsUpdate(pis.Select(i => i.Name), pis.Select(i => i.GetValue(entity)));
        }
    }
}
