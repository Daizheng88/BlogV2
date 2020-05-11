using System;

namespace Blog.Contract.Mapper.Core
{
    public class NumberMapper : IMapper<byte>, IMapper<short>, IMapper<int>, IMapper<long>, IMapper<float>, IMapper<double>, IMapper<decimal>,
        IMapper<byte?>, IMapper<short?>, IMapper<int?>, IMapper<long?>, IMapper<float?>, IMapper<double?>, IMapper<decimal?>
    {
        private static Type StringType = typeof(string);

        private static Type ByteType = typeof(byte);

        private static Type ShortType = typeof(short);

        private static Type IntType = typeof(int);

        private static Type LongType = typeof(long);

        private static Type FloatType = typeof(float);

        private static Type DoubleType = typeof(double);

        private static Type DecimalType = typeof(decimal);

        public object To<TTarget>(byte source)
        {
            // 取得目标类型
            Type targetType = typeof(TTarget);

            if (targetType.Equals(StringType))
            {
                return source.ToString();
            }
            else if (targetType.Equals(ByteType))
            {
                return source;
            }
            else
            {
                throw new InvalidOperationException("Invalid mapping");
            }
        }

        public object To<TTarget>(long source)
        {
            // 取得目标类型
            Type targetType = typeof(TTarget);

            if (targetType.Equals(StringType))
            {
                return source.ToString();
            }
            else if (targetType.Equals(LongType))
            {
                return source;
            }
            else
            {
                throw new InvalidOperationException("Invalid mapping");
            }
        }

        public object To<TTarget>(int source)
        {
            // 取得目标类型
            Type targetType = typeof(TTarget);

            if (targetType.Equals(StringType))
            {
                return source.ToString();
            }
            else if (targetType.Equals(IntType))
            {
                return source;
            }
            else
            {
                throw new InvalidOperationException("Invalid mapping");
            }
        }

        public object To<TTarget>(short source)
        {
            // 取得目标类型
            Type targetType = typeof(TTarget);

            if (targetType.Equals(StringType))
            {
                return source.ToString();
            }
            else if (targetType.Equals(ShortType))
            {
                return source;
            }
            else
            {
                throw new InvalidOperationException("Invalid mapping");
            }
        }

        public object To<TTarget>(double source)
        {
            // 取得目标类型
            Type targetType = typeof(TTarget);

            if (targetType.Equals(StringType))
            {
                return source.ToString();
            }
            else if (targetType.Equals(DoubleType))
            {
                return source;
            }
            else
            {
                throw new InvalidOperationException("Invalid mapping");
            }
        }

        public object To<TTarget>(decimal source)
        {
            // 取得目标类型
            Type targetType = typeof(TTarget);

            if (targetType.Equals(StringType))
            {
                return source.ToString();
            }
            else if (targetType.Equals(DecimalType))
            {
                return source;
            }
            else
            {
                throw new InvalidOperationException("Invalid mapping");
            }
        }

        public object To<TTarget>(float source)
        {
            // 取得目标类型
            Type targetType = typeof(TTarget);

            if (targetType.Equals(StringType))
            {
                return source.ToString();
            }
            else if (targetType.Equals(FloatType))
            {
                return source;
            }
            else
            {
                throw new InvalidOperationException("Invalid mapping");
            }
        }

        public object To<TTarget>(long? source)
        {
            return source.HasValue ? To<TTarget>(source.Value) : null;
        }

        public object To<TTarget>(int? source)
        {
            return source.HasValue ? To<TTarget>(source.Value) : null;
        }

        public object To<TTarget>(short? source)
        {
            return source.HasValue ? To<TTarget>(source.Value) : null;
        }

        public object To<TTarget>(byte? source)
        {
            return source.HasValue ? To<TTarget>(source.Value) : null;
        }

        public object To<TTarget>(decimal? source)
        {
            return source.HasValue ? To<TTarget>(source.Value) : null;
        }

        public object To<TTarget>(double? source)
        {
            return source.HasValue ? To<TTarget>(source.Value) : null;
        }

        public object To<TTarget>(float? source)
        {
            return source.HasValue ? To<TTarget>(source.Value) : null;
        }
    }
}
