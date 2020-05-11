using System;

namespace Blog.Contract.Mapper.Core
{
    public class DateTimeMapper : IMapper<DateTime>, IMapper<DateTime?>
    {
        public static Type StringType = typeof(string);

        public static Type DateTimeType = typeof(DateTime);

        public object To<TTarget>(DateTime source)
        {
            // 取得目标类型
            Type targetType = typeof(TTarget);

            if (targetType.Equals(StringType))
            {
                return source.ToString();
            }
            else if (targetType.Equals(DateTimeType))
            {
                return source;
            }
            else
            {
                throw new InvalidOperationException("Invalid mapping");
            }
        }

        public object To<TTarget>(DateTime? source)
        {
            return source.HasValue ? To<TTarget>(source.Value) : null;
        }
    }
}
