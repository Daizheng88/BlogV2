using System;

namespace Blog.Contract.Mapper.Core
{
    public class GuidMapper : IMapper<Guid>, IMapper<Guid?>
    {
        private static Type StringType = typeof(string);

        private static Type GuidType = typeof(Guid);

        public object To<TTarget>(Guid source)
        {
            // 取得目标类型
            Type targetType = typeof(TTarget);

            if (targetType.Equals(StringType))
            {
                return source.ToString();
            }
            else if (targetType.Equals(GuidType))
            {
                return source;
            }
            else
            {
                throw new InvalidOperationException("Invalid mapping");
            }
        }

        public object To<TTarget>(Guid? source)
        {
            return source.HasValue ? To<TTarget>(source.Value) : null;
        }
    }
}
