using System;
using System.Collections.Generic;

namespace Blog.Contract.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static void Each<TSource>(this IEnumerable<TSource> source, Action<TSource> callback)
        {
            foreach (TSource item in source)
            {
                callback(item);
            }
        }
    }
}
